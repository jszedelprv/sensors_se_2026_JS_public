
namespace MyKai.Communicator
{
    public interface IKaiCommunicable
    {
        void ResponseKaiEvent();
        void ResponseSpecialAction();
        ControlResponseDelegateType GetKaiMessagetDelegate();
        ControlResponseDelegateType GetKaiSpecialActionDelegate();
        bool CheckIfFormExists();
    }
}
