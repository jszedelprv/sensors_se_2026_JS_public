
namespace MyKai.Data
{
    public abstract class KaiDataFilterBase
    {
        public string FilterName { get; set;  }

        public dynamic RequiredValue { get; set; }

        public KaiDataFilterBase() {}

        public KaiDataFilterBase(string pFilterName)
        {
            FilterName = pFilterName;
        }

        public abstract bool CheckCondition(KaiDataObjectBase pObject);
    }
}
