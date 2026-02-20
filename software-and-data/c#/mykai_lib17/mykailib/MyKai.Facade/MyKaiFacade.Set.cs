using System.Drawing;

namespace MyKai.Facade
{
    public partial class MyKaiFacade
    {
        public class SetSubclass
        {
            MyKaiFacade parent;

            public SetSubclass(MyKaiFacade pParent)
            {
                this.parent = pParent;
            }
        }
    }
}
