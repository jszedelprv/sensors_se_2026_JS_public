using System;
using System.Windows.Forms;

namespace MyKai.General
{
    public abstract class MyKaiBuilderBase<T> where T : new()
    {
        protected T instance { get; set; }

        public MyKaiBuilderBase()
        {
            if (ShouldCreateInstance())
                instance = CreateInstance();
        }

        protected virtual T CreateInstance(object[] pArgs = null)
        {
            T newInstance = MyKaiFactory.Produce<T>(pArgs);
            return newInstance;
        }

        protected virtual bool ShouldCreateInstance()
        {
            return true;
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
                MessageBox.Show(e.Message, "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return instance;            
            }
        }

        public virtual bool IsInstanceBuildComplette()
        {
            return true;
        }
    }

    public class MyKaiDefaultBuilder<T> : MyKaiBuilderBase<T> where T : new()
    {
        public MyKaiDefaultBuilder(object[] pArgs = null)
        {
            instance = CreateInstance(pArgs);
        }

        protected override bool ShouldCreateInstance()
        {
            return false;
        }
    }
}
