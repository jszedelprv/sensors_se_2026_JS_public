import os
import shutil
import sys

samples_folder = 'samples'
beziers_folder = 'beziers'
as_capture_folder = 'as-captured'

def prepere_dataset(source_path, dataset_name):
    for file_name in os.listdir(source_path):
        if os.path.isfile(os.path.join(source_path, file_name)):
            class_name = file_name.split('_')[1]
            initials = file_name.split('_')[0]
            type = os.path.basename(source_path)
            dest_folder = os.path.join('.\\datasets', dataset_name, type, initials, class_name)
            os.makedirs(dest_folder, exist_ok=True)
            shutil.copy(os.path.join(source_path, file_name), os.path.join(dest_folder, file_name))

if __name__ == "__main__":
    dataset_path = "..\\..\\workspace\\datasets"
    
    for dataset in os.listdir(dataset_path):
        if not os.path.isdir(os.path.join(dataset_path, dataset)):
            break
        
        dataset_path = os.path.join(dataset_path, dataset, samples_folder)

        if not os.path.exists(dataset_path):
            break
        
        beziers_path = os.path.join(dataset_path, beziers_folder)
        as_capture_path = os.path.join(dataset_path, as_capture_folder)
        
        if os.path.exists(beziers_path):
            prepere_dataset(beziers_path, dataset)

        if os.path.exists(as_capture_path):
            prepere_dataset(as_capture_path, dataset)

        
    
