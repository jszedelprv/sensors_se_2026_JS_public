from  methods import make_experiment
from models import three_conv, four_conv, five_conv, flowers_model

IMAGE_SIZE = 64
N_VAL = 2
N_LEA = 9
AUGM_RATIO = 0.2
DROP_RATE = 0.4
DATA_PART = "as-captured"

experiments = [
    make_experiment(
        personal_dataset_path=r"datasets\sensors-2026-wirst-forearm" + "\\" + DATA_PART + "\\" + "jasz", casual_gestures_dataset_path=r"datasets\sensors-2026-wirst-forearm" + "\\" + DATA_PART + "\\" + "cash", name='flowers_model jasz', 
        dropout_rate=DROP_RATE, input_shape=(IMAGE_SIZE, IMAGE_SIZE, 1), model_gen=flowers_model, epochs=30, samples_per_class_train=N_LEA, samples_per_class_val=N_VAL, rotation_factor=AUGM_RATIO, translation_factor=AUGM_RATIO, zoom_factor=AUGM_RATIO, repetitions=10
    ),
    make_experiment(
        personal_dataset_path=r"datasets\sensors-2026-wirst-forearm" + "\\" + DATA_PART + "\\" + "szsz", casual_gestures_dataset_path=r"datasets\sensors-2026-wirst-forearm" + "\\" + DATA_PART + "\\" + "cash", name='flowers_model szsz', 
        dropout_rate=DROP_RATE, input_shape=(IMAGE_SIZE, IMAGE_SIZE, 1), model_gen=flowers_model, epochs=30, samples_per_class_train=N_LEA, samples_per_class_val=N_VAL, rotation_factor=AUGM_RATIO, translation_factor=AUGM_RATIO, zoom_factor=AUGM_RATIO, repetitions=10
    ),
    make_experiment(
        personal_dataset_path=r"datasets\sensors-2026-wirst-forearm + "\\" + DATA_PART + "\\" + "kals", casual_gestures_dataset_path=r"datasets\sensors-2026-wirst-forearm" + "\\" + DATA_PART + "\\" + "cash", name='flowers_model kals', 
        dropout_rate=DROP_RATE, input_shape=(IMAGE_SIZE, IMAGE_SIZE, 1), model_gen=flowers_model, epochs=30, samples_per_class_train=N_LEA, samples_per_class_val=N_VAL, rotation_factor=AUGM_RATIO, translation_factor=AUGM_RATIO, zoom_factor=AUGM_RATIO, repetitions=10
    ),
    make_experiment(
        personal_dataset_path=r"datasets\sensors-2026-wirst-forearm" + "\\" + DATA_PART + "\\" + "wosz", casual_gestures_dataset_path=r"datasets\sensors-2026-wirst-forearm" + "\\" + DATA_PART + "\\" + "cash", name='flowers_model wosz', 
        dropout_rate=DROP_RATE, input_shape=(IMAGE_SIZE, IMAGE_SIZE, 1), model_gen=flowers_model, epochs=30, samples_per_class_train=N_LEA, samples_per_class_val=N_VAL, rotation_factor=AUGM_RATIO, translation_factor=AUGM_RATIO, zoom_factor=AUGM_RATIO, repetitions=10
    ),
    make_experiment(
        personal_dataset_path=r"datasets\sensors-2026-wirst-forearm" + "\\" + DATA_PART + "\\" + "apsz", casual_gestures_dataset_path=r"datasets\sensors-2026-wirst-forearm" + "\\" + DATA_PART + "\\" + "cash", name='flowers_model apsz', 
        dropout_rate=DROP_RATE, input_shape=(IMAGE_SIZE, IMAGE_SIZE, 1), model_gen=flowers_model, epochs=30, samples_per_class_train=N_LEA, samples_per_class_val=N_VAL, rotation_factor=AUGM_RATIO, translation_factor=AUGM_RATIO, zoom_factor=AUGM_RATIO, repetitions=10
    ),
]

