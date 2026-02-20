using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKai.Data
{
    public class KaiDataFieldCollection
    {
        public List<(int Index, FieldInfo Info)> Items;

        public FindFieldTask Find = new FindFieldTask();

        public KaiDataFieldCollection()
        {
            Items = new List<(int Index, FieldInfo Info)>();
        }

        public class FindFieldTask
        {
        }
    }
}
