using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKai.General
{
    public class MyKaiPrefixNumberFileNameMaker : MyKaiFileNameMakerBase
    {
        public override string MakeFileName(object[] pParams)
        {
            string result = "";
            string filePrefix = (string)pParams[0];
            int fileNumber = (int)pParams[1];
            
            if (ChceckParams(pParams))
                result = filePrefix + "_" + fileNumber.ToString("D3");

            return result;
        }

        protected override bool ChceckParams(object[] pParams)
        {
            if (pParams.Length == 2)
                if (pParams[0].GetType() == typeof(string) && pParams[1].GetType() == typeof(int))
                    return true;
            
            return false;
        }
    }
}
