using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyKai.Data.Attributes;

namespace MyKai.Data.Entities
{
    public class ImageDataset : KaiDataFolderObjectBase
    {
        public static ImageDataset Build(string pName, string pFolderPath)
        {
            ImageDataset newImageDataset = new ImageDataset();
            
            newImageDataset.Name = pName;
            newImageDataset.FolderPath = pFolderPath;

            return newImageDataset;
        }
    }

    [KaiDataEntity(EntityName = "ImageDatasets", RelativePath = "\\datasets")]
    public class ImageDatasetEntity : KaiDataEntityBase
    {
        protected override void Deserialize()
        {
            foreach (string folderPath in Directory.GetDirectories(RelativePath()))
            {
                string dirName = Path.GetFileName(folderPath);
                ImageDataset newItem = ImageDataset.Build(dirName, folderPath);
                Objects.Items.Add(newItem);
            }
        }

        public override string RelativePath() => KaiDataWorkspace.WorkspaceRelativePath
                                               + KaiDataWorkspace.Find.RecordByEntityName("ImageDatasets").RelativePath;

        public override Type GetObjectType() => typeof(ImageDataset);

        public override KaiDataObjectBase GetNewObject()
        {
            throw new NotImplementedException();
        }
    }
}
