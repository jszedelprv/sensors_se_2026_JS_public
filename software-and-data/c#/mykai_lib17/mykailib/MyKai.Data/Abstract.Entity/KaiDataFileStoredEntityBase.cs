using System;
using System.IO;
using MyKai.Data.Attributes;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKai.Data
{
     public abstract class KaiDataFileStoredEntityBase : KaiDataEntityBase
     {
        public KaiDataFieldCollection Fields { get; set; }
        public string FileName { get; set; }
        public string FileExtention { get; set; }

        private static Dictionary<string, IKaiDataFileReader> fileReaders = new Dictionary<string, IKaiDataFileReader>();

        public KaiDataFileStoredEntityBase() : base()
        {
            Fields = new KaiDataFieldCollection();
            FileName = FileNameAttributeValue();
            FileExtention = Path.GetExtension(FileName);
            CreateAndRegisterReaders();
        }

        private static void CreateAndRegisterReaders()
        {
            fileReaders.Add(".csv", new KaiDataCSVFileReader());
        }

        protected  IKaiDataFileReader GetFileReader() => fileReaders[FileExtention];

        protected abstract string FileNameAttributeValue();
    }
}
