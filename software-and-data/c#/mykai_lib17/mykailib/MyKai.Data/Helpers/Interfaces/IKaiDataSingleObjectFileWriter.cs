
using System;

namespace MyKai.Data
{
    internal interface IKaiDataSingleObjectFileWriter
    {
        void SaveObject(KaiDataObjectBase pObject);
        void PrepareSave(string pFilename);
    }
}
