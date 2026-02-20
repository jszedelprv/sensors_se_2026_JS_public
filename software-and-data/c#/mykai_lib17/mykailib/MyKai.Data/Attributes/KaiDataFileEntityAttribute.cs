using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKai.Data.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true) ]
    public class KaiDataFileEntityAttribute : KaiDataEntityAttribute
    {
        public string FileName = "";
    }
}
