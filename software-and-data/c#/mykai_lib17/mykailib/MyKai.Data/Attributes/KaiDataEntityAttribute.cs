using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKai.Data.Attributes
{
    [Flags]
    public enum EntityOptions : UInt32
    {
        None = 0,
        DeserializeOnRefresh = 1
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true) ]
    public class KaiDataEntityAttribute : Attribute
    {
        public KaiDataEntityAttribute() : base()
        {
            EntityOptions = DefaultEntityOptions;
        }

        public string EntityName;
        public string RelativePath;
        public string Subdirectory;
        
        public EntityOptions EntityOptions;
        public const EntityOptions DefaultEntityOptions = EntityOptions.DeserializeOnRefresh;
    }
}
