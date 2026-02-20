using System;
using System.Windows.Forms;

namespace MyKai.Data
{
    public abstract class KaiDataBuilderBase<T> where T : new()
    {
        protected T instance { get; set; }

        protected KaiDataBuilderBase()
        {
            instance = CreateInstance();
        }

        protected T CreateInstance(object[] pArgs = null)
        {
            instance = KaiDataFactory.Produce<T>(pArgs);
            return instance;
        }

        public virtual T Build()
        {
            try
            {
                if (IsInstanceBuildComplette())
                    return instance;
                else
                    throw new NullReferenceException($"{this.GetType().Name}.Build(): Can't build the instance. Not all required members/depandencies are set for class: " + typeof(T).Name);
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return instance;
            }
        }

        public virtual bool IsInstanceBuildComplette()
        {
            return true;
        }
    }

    public class KaiDataDefaultBuilder<T> : KaiDataBuilderBase<T> where T : new()
    {
        public KaiDataDefaultBuilder(object[] pArgs = null)
        {
            instance = CreateInstance(pArgs);
        }
    }
}
