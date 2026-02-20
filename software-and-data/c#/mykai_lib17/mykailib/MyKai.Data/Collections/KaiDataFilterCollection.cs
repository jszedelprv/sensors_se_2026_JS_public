using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKai.Data
{
    public class KaiDataFilterCollection
    {
        public List<KaiDataFilterBase> Items;

        public KaiDataFilterCollection()
        {
            Items = new List<KaiDataFilterBase>();
        }

        public bool CheckAll(KaiDataObjectBase pObject)
        {
            if (Items.Count == 0)
                return true;

            bool result = true;

            foreach (KaiDataFilterBase filter in Items)
                result &= filter.CheckCondition(pObject);

            return result;
        }

        public KaiDataFilterBase FilterByName(string pFilterName)
        {
            return Items.Find( x => x.FilterName == pFilterName );
        }
    }
}
