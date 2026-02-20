
using MyKai.Communicator;
using MyKai.Manager;
using MyKai.Gesture;
using System.Runtime.InteropServices.WindowsRuntime;

namespace MyKai.Facade
{
    public partial class MyKaiFacade
    {
        internal FacadeComponentHolder ComponentHolder = null;
        internal FacadeComponentInitializer ComponentInitializer = null;
        public GetSubclass Get = null;
        public SetSubclass Set = null;
        public ActionSubclass Action = null;
        public QuerySubclass Query = null;

        internal MyKaiFacade() { } // The class is built using the BuilderOfMyKaiFacade class.
                                   // The constructor is internal to prevent direct instantiation.
    }
}
