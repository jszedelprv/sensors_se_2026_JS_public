using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKai.Data
{
    public static class KaiDataFactory
    {
        public static dynamic Produce<T>(object[] pArgs = null)
        {
            if (pArgs == null)
            {
                return Activator.CreateInstance(typeof(T)); ;
            }
            else
            {
                return Activator.CreateInstance(typeof(T), pArgs);
            }
        }

        public static dynamic Produce(Type pType, object[] pArgs = null)
        {
            if (pArgs == null)
            {
                return Activator.CreateInstance(pType);
            }
            else
            {
                return Activator.CreateInstance(pType, pArgs);
            }
        }
    }
}
