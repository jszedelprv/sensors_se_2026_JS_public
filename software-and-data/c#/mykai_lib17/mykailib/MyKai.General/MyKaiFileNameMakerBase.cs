using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKai.General
{
    public abstract class MyKaiFileNameMakerBase
    {
        public abstract string MakeFileName(object[] pParams);
        protected abstract bool ChceckParams(object[] pParams);
    }
}
