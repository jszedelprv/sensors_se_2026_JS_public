
namespace MyKai.Data
{
    public interface IKaiDataFileReader
    {
        KaiDataObjectCollection ReadObjects(KaiDataFileStoredEntityBase pfileEntity);
    }
}
