using MyKai.Data.Entities;
using MyKai.General;
using System.IO;

namespace MyKai.Data
{
    public abstract class KaiDataGestureImageBase : KaiDataImageObjectBase
    {
    }

    public abstract class KaiDataImageEntityBase : KaiDataEntityBase
    {
        public bool OverwriteOnSave { get; set; } = false;

        protected override void Deserialize()
        {
            DeserializeImages();
        }

        private void DeserializeImages()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(RelativePath());

            foreach (FileInfo fileInfo in dirInfo.GetFiles())
            {
                if (IsAnImageFile(fileInfo.Name))
                    Objects.Items.Add(BuildImage(fileInfo.Name, fileInfo.FullName));
            }
        }

        protected override void Serialize()
        {
            SerializeImages();
        }

        private void SerializeImages()
        {
            MyKaiJPGImageSaver saver = new MyKaiJPGImageSaver();

            foreach (GestureImage gestureImage in Objects.Items)
            {
                if (saver.CheckIfImageExists(gestureImage.ImageFileFullName))
                {
                    if (!OverwriteOnSave)
                        continue; // skip saving if file already exists and OverwriteOnSave is false
                    else
                        saver.PrepareSave(gestureImage.ImageFileFullName); // deletes existing file if OverwriteOnSave is true
                }
                
                saver.SaveImage(gestureImage.GestureImage, gestureImage.ImageFileFullName);
            }
        }

        protected abstract KaiDataImageObjectBase BuildImage(string pName, string pFullName);

        private bool IsAnImageFile(string pName)
        {
            string extention = Path.GetExtension(pName);
            return extention == ".jpg"  || extention == ".bmp"; // TO DO: supply variable extentions if needed
        }
    }
}
