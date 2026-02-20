using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKai.Data
{
    internal interface IKaiDataSingleObjectFileReader
    {
        void ReadObject(KaiDataObjectBase pObject);
    }
}
