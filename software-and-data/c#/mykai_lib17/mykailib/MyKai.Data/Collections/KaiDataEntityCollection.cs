using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKai.Data
{
    public class KaiDataEntityCollection
    {
        public List<IKaiDataEntity> Items;        

        public KaiDataEntityCollection()
        {
            Items = new List<IKaiDataEntity>();
        }
    }
}
