using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKai.Data
{
    public class KaiDataSubstringFilter : KaiDataFilterBase
    {
        public (int StartIndex, int Length) SubstringParameters;

        public override bool CheckCondition(KaiDataObjectBase pObject)
        {
            string prefix = pObject.Name.Substring(SubstringParameters.StartIndex, SubstringParameters.Length);
            return (string)RequiredValue == prefix;
        }
    }
}
