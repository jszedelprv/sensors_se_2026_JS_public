import time
import os
from sklearn.model_selection import train_test_split
import tensorflow as tf
from models import four_conv
import pandas as pd

def make_experiment(personal_dataset_path, casual_gestures_dataset_path, name=None, batch_size=32, epochs=20, learning_rate=0.001, dropout_rate=0.5, samples_per_class_train=8,
                     samples_per_class_val=2, input_shape=(640, 640, 1), rotation_factor=0.1,
                     zoom_factor=0.1, translation_factor=0.1, model_gen=four_conv, repetitions=1):
    
    personal_dataset_path = './' + personal_dataset_path.replace('\\', '/')
    
    experiment = {
        'personal_dataset_path': personal_dataset_path,
        'casual_gestures_dataset_path': casual_gestures_dataset_path,
        'name': name,
        'batch_size': batch_size,
        'epochs': epochs,
        'learning_rate': learning_rate,
        'dropout_rate': dropout_rate,
        'samples_per_class_train': samples_per_class_train,
        'samples_per_class_val': samples_per_class_val,
        'input_shape': input_shape,
        'rotation_factor': rotation_factor,
        'zoom_factor': zoom_factor,
        'translation_factor': translation_factor,
        'model_gen': model_gen,
        'repetitions': repetitions
    }

    check_experiment(experiment)

    return experiment
    
def check_experiment(experiment):
    assert isinstance(experiment['personal_dataset_path'], str), "personal_dataset_path must be a string"
    assert isinstance(experiment['casual_gestures_dataset_path'], str), "casual_gestures_dataset_path must be a string"
    assert isinstance(experiment['name'], (str, type(None))), "name must be a string or None"
    assert isinstance(experiment['batch_size'], int) and experiment['batch_size'] > 0, "batch_size must be a positive integer"
    assert isinstance(experiment['epochs'], int) and experiment['epochs'] > 0, "epochs must be a positive integer"
    assert isinstance(experiment['samples_per_class_train'], int) and experiment['samples_per_class_train'] > 0, "samples_per_class_train must be a positive integer"
    assert isinstance(experiment['samples_per_class_val'], int) and experiment['samples_per_class_val'] > 0, "samples_per_class_val must be a positive integer"
    assert isinstance(experiment['input_shape'], tuple) and len(experiment['input_shape']) == 3, "input_shape must be a tuple of three integers"
    assert all(isinstance(i, int) and i > 0 for i in experiment['input_shape']), "input_shape values must be positive integers"
    assert isinstance(experiment['rotation_factor'], float) and 0 <= experiment['rotation_factor'] <= 1, "rotation_factor must be a float between 0 and 1"
    assert isinstance(experiment['zoom_factor'], float) and 0 <= experiment['zoom_factor'] <= 1, "zoom_factor must be a float between 0 and 1"
    assert isinstance(experiment['translation_factor'], float) and 0 <= experiment['translation_factor'] <= 1, "translation_factor must be a float between 0 and 1"
    assert callable(experiment['model_gen']), "model_gen must be a callable function"
    assert os.path.exists(experiment['personal_dataset_path']), f"personal_dataset_path '{experiment['personal_dataset_path']}' does not exist"
    assert os.path.exists(experiment['casual_gestures_dataset_path']), f"casual_gestures_dataset_path '{experiment['casual_gestures_dataset_path']}' does not exist"
    assert isinstance(experiment['learning_rate'], float) and experiment['learning_rate'] > 0, "learning_rate must be a positive float"
    assert isinstance(experiment['dropout_rate'], float) and 0 <= experiment['dropout_rate'] <= 1, "dropout_rate must be a float between 0 and 1"
    assert isinstance(experiment['repetitions'], int) and 0 <= experiment['repetitions'], "repetitions must be an integer greater than 0"

    if experiment['name'] is not None:
        assert len(experiment['name']) > 0, "name must not be empty"
        # Disallow characters generally invalid for filenames on Windows/Unix and the null char
        invalid_chars = set('/\\<>:"|?*\0')
        if any(c in invalid_chars for c in experiment['name']):
            raise AssertionError("name contains invalid characters for file/folder names")
        # No leading/trailing whitespace, and must not end with a dot or space (Windows restriction)
        assert experiment['name'] == experiment['name'].strip(), "name must not have leading or trailing whitespace"
        assert not (experiment['name'].endswith('.') or experiment['name'].endswith(' ')), "name must not end with a dot or space"
        # Disallow common reserved Windows names (compare base name before any extension)
        base = experiment['name'].split('.')[0].upper()
        reserved = {'CON', 'PRN', 'AUX', 'NUL'} | {f'COM{i}' for i in range(1, 10)} | {f'LPT{i}' for i in range(1, 10)}
        assert base not in reserved, "name is a reserved Windows filename"

def generate_experiment_time():
    delimeter = '-'
    experiment_time = delimeter.join(time.asctime(time.localtime()).split(' ')[-3:])
    return experiment_time

def read_dataset(path):
    for class_name in os.listdir(path):
        class_path = os.path.join(path, class_name)
        if os.path.isdir(class_path):
            for img_name in os.listdir(class_path):
                img_path = os.path.join(class_path, img_name)
                yield img_path, class_name

def get_samples_and_labels(path):
    return zip(*read_dataset(path))

def make_stratified_splits(samples, labels, val_size, test_size, random_state=42):
    samples_train, samples_val, labels_train, labels_val = train_test_split(
        samples, labels, test_size=val_size + test_size, stratify=labels, random_state=random_state
    )
    
    if test_size > 0:
        samples_val, samples_test, labels_val, labels_test = train_test_split(
            samples_val, labels_val, test_size=test_size, stratify=labels_val, random_state=random_state
        )
    
    train_dataset = tf.data.Dataset.from_tensor_slices((samples_train, labels_train))
    val_dataset = tf.data.Dataset.from_tensor_slices((samples_val, labels_val))
    test_dataset = None

    if test_size > 0:
        test_dataset = tf.data.Dataset.from_tensor_slices((samples_test, labels_test))

    return train_dataset, val_dataset, test_dataset

def make_lookup_table(class_names):
    keys_tensor = tf.constant(class_names, dtype=tf.string)
    vals_tensor = tf.constant(list(range(len(class_names))), dtype=tf.int64)
    keys_to_vals = tf.lookup.StaticHashTable(
        tf.lookup.KeyValueTensorInitializer(keys_tensor, vals_tensor),
        default_value=-1
    )
    vals_to_keys = tf.lookup.StaticHashTable(
        tf.lookup.KeyValueTensorInitializer(vals_tensor, keys_tensor),
        default_value="NONE"
    )
    
    return keys_to_vals, vals_to_keys

def load_and_preprocess_image(path, label, class_to_idx_table, input_shape, NUM_CLASSES):
    image = tf.io.read_file(path)
    image = tf.image.decode_png(image, channels=1)
    image = tf.image.resize(image, input_shape[:2])
    image = image / 255.0
    label = class_to_idx_table.lookup(label)
    if (label == -1):
        label = tf.zeros(NUM_CLASSES) 
    else:
        label = tf.one_hot(label, depth=NUM_CLASSES)
    return image, label

def one_hot_to_class(one_hot_label, class_names):
    idx = tf.argmax(one_hot_label).numpy()
    return class_names[idx]

def make_metric_data_frame(experiment, experiment_histories, metric):
    return pd.DataFrame({'repetition': [i for i in range(experiment['repetitions']) for _ in range(experiment['epochs'])],
    'epoch': [i + 1 for _ in range(experiment['repetitions']) for i in range(experiment['epochs'])],
    metric: [loss for history in experiment_histories for loss in history.history[metric]]})

def flatten_metric_data_frame(metric_data_frame, metric, number_of_experiments):
    return pd.DataFrame({'repetition': [repetition for i in range(number_of_experiments) for repetition in metric_data_frame[i]['repetition']],
    'epoch': [epoch for i in range(number_of_experiments) for epoch in metric_data_frame[i]['epoch']],
    metric: [loss for i in range(number_of_experiments) for loss in metric_data_frame[i][metric]]})