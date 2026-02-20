using MyKai.Manager;

namespace MyKai.GUI
{
    public interface IKaiLoggingAwareClass
    {
        IKaiEventLogger KaiEventLogger { get; }
        IKaiMessageLogUserControl KaiMessageLogUserControl { get; }
    }
}
