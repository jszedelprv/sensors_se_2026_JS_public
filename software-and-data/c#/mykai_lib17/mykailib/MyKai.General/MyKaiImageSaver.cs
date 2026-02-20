using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyKai.General
{
    internal abstract class MyKaiImageSaverBase
    {
        public abstract void SaveImage(Image pImage, string pFilename);

        public bool CheckIfImageExists(string pFilename) => File.Exists(pFilename);
        
        internal void PrepareSave(string pFilename)
        {
            try
            {
                File.Delete(pFilename);
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting image file: {pFilename}. {e.Message}");
            }
        }
    }
}
