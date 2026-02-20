using System;

namespace MyKai.General
{
    internal static class MyKaiFactory
    {
        public static T Produce<T>(object[] pArgs = null) where T : new()
        {
            if (MyKaiClassRegistry.IsClassRegistered<T>())           // Only registered classes are created
                return MyKaiGenericFactory<T>.Create(pArgs);
            else
                throw new NotSupportedException($"{typeof(MyKaiFactory).Name} does not support {typeof(T).Name} class.");
        }
        
        private static class MyKaiGenericFactory<T>
        {
            public static T Create(object[] pArgs = null)
            {
                if (pArgs == null)
                {
                    var createdNoParams = (T)Activator.CreateInstance(typeof(T));
                    return createdNoParams;
                }
                else
                {
                    var createdParams = (T)Activator.CreateInstance(typeof(T), pArgs);
                    return createdParams;
                }
            }
        }    
    }
}
