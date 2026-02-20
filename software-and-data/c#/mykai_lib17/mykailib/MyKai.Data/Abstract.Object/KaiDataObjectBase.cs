using MyKai.Data.Attributes;

namespace MyKai.Data
{   
    public abstract class KaiDataObjectBase
    {          
        public string Name { get; set; }
        public bool IsInCollection(KaiDataObjectCollection pCollection) => pCollection.Items.Contains(this);
    }
}
