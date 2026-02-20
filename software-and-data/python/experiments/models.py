import tensorflow as tf
from tensorflow.keras import layers, Sequential
from tensorflow.keras.layers import Conv2D, MaxPooling2D, Flatten, Dense

def make_augmentation(rotation_factor, zoom_factor, translation_factor):
    assert isinstance(rotation_factor, float) and 0 <= rotation_factor <= 1, "rotation_factor must be a float between 0 and 1"
    assert isinstance(zoom_factor, float) and 0 <= zoom_factor <= 1, "zoom_factor must be a float between 0 and 1"
    assert isinstance(translation_factor, float) and 0 <= translation_factor <= 1, "translation_factor must be a float between 0 and 1"
    
    data_augmentation = tf.keras.Sequential()
    
    if rotation_factor > 0:
        data_augmentation.add(
            tf.keras.layers.RandomRotation(
                factor=rotation_factor,
                fill_mode='constant',
                fill_value=1.0
            )
        )
    
    if zoom_factor > 0:
        data_augmentation.add(
            tf.keras.layers.RandomZoom(
                height_factor=zoom_factor,
                width_factor=zoom_factor,
                fill_mode='constant',
                fill_value=1.0
            )
        )
    
    if translation_factor > 0:
        data_augmentation.add(
            tf.keras.layers.RandomTranslation(
                height_factor=translation_factor,
                width_factor=translation_factor,
                fill_mode='constant',
                fill_value=1.0
            )
        )
    
    return data_augmentation

def flowers_model(input_shape, NUM_CLASSES, learning_rate, dropout_rate):
    model = Sequential([
        layers.Conv2D(32, 3, padding='same', activation='relu',
                    input_shape=input_shape),
        layers.MaxPooling2D(),
        layers.Conv2D(32, 3, padding='same', activation='relu'),
        layers.MaxPooling2D(),
        layers.Conv2D(32, 3, padding='same', activation='relu'),
        layers.MaxPooling2D(),
        layers.Flatten(),
        layers.Dense(128, activation='relu'),
        layers.Dropout(dropout_rate),
        layers.Dense(NUM_CLASSES)
    ])

    model.compile(optimizer='adam',
                loss=tf.keras.losses.CategoricalCrossentropy(from_logits=True),
                metrics=['accuracy'])
    return model


def three_conv(input_shape, NUM_CLASSES, learning_rate, dropout_rate):
    model = Sequential([
        layers.Conv2D(16, 3, padding='same', activation='relu',
                    input_shape=input_shape),
        layers.MaxPooling2D(),
        layers.Conv2D(32, 3, padding='same', activation='relu'),
        layers.MaxPooling2D(),
        layers.Conv2D(64, 3, padding='same', activation='relu'),
        layers.MaxPooling2D(),
        layers.Flatten(),
        layers.Dense(128, activation='relu'),
        layers.Dropout(dropout_rate),
        layers.Dense(NUM_CLASSES)
    ])

    model.compile(optimizer='adam',
                loss=tf.keras.losses.CategoricalCrossentropy(from_logits=True),
                metrics=['accuracy'])
    return model

def four_conv(input_shape, NUM_CLASSES, learning_rate, dropout_rate):
    model = Sequential([
        layers.Conv2D(16, 3, padding='same', activation='relu',
                    input_shape=input_shape),
        layers.MaxPooling2D(),
        layers.Conv2D(32, 3, padding='same', activation='relu'),
        layers.MaxPooling2D(),
        layers.Conv2D(64, 3, padding='same', activation='relu'),
        layers.MaxPooling2D(),
        layers.Conv2D(128, 3, padding='same', activation='relu'),
        layers.MaxPooling2D(),
        layers.Flatten(),
        layers.Dense(128, activation='relu'),
        layers.Dropout(dropout_rate),
        layers.Dense(NUM_CLASSES)
    ])

    model.compile(optimizer='adam',
                loss=tf.keras.losses.CategoricalCrossentropy(from_logits=True),
                metrics=['accuracy'])
    return model

def five_conv(input_shape, NUM_CLASSES, learning_rate, dropout_rate):
    model = Sequential([
        layers.Conv2D(16, 3, padding='same', activation='relu',
                    input_shape=input_shape),
        layers.MaxPooling2D(),
        layers.Conv2D(32, 3, padding='same', activation='relu'),
        layers.MaxPooling2D(),
        layers.Conv2D(64, 3, padding='same', activation='relu'),
        layers.MaxPooling2D(),
        layers.Conv2D(128, 3, padding='same', activation='relu'),
        layers.MaxPooling2D(),
        layers.Conv2D(256, 3, padding='same', activation='relu'),
        layers.MaxPooling2D(),
        layers.Flatten(),
        layers.Dense(256, activation='relu'),
        layers.Dropout(dropout_rate),
        layers.Dense(NUM_CLASSES)
    ])

    model.compile(optimizer='adam',
                loss=tf.keras.losses.CategoricalCrossentropy(from_logits=True),
                metrics=['accuracy'])
    return model