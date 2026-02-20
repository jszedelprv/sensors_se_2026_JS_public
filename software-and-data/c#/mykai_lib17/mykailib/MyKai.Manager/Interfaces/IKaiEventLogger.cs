namespace MyKai.Manager
{
    public interface IKaiEventLogger
    {
        bool IncludeMessageCounter { get; set; }

        void AddMessage(string pMessage);
        void DoClassSpecificAddMessageActions(string pMessage);
    }
}