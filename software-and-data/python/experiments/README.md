# Librries that need to be installed

1. tensorflow                   2.10.0
2. scikit-learn                 1.3.2
3. matplotlib                   3.10.3

NOTE: versions do not have to be exact

# Important files

1. dataset_structure_prep.py -> Run it to create proper dataset structure in the ./ directory.
2. experiments.py -> define experiments that will be conducted in main.ipynb.
3. models.py -> define model returning functions used in experiments definition.
4. main.ipynb -> Run it to conduct experiments defined in models.py

# Important folders

1. datasets -> contain dataset which paths need to be specified in experiments (needs to be created using dataset_structure_prep.py)
2. metrics -> contain metrics of conducted experiments (needs to be created by the last block of main.py)