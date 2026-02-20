using System;

namespace MyKai.Data
{
    public interface IKaiDataEntity
    {
        string EntityName { get; set; }
        KaiDataObjectCollection Objects { get; set; }
        KaiDataFilterCollection Filters { get; set; }
        KaiDataControlCollection ManagedControls { get; set; }
        string RelativePath();
        Type GetObjectType(); 
        void LoadInstances();
        void SaveInstances();
        void DeleteInstances( KaiDataObjectCollection pInstancesToDel );
        KaiDataObjectBase GetNewObject();
        void RefreshDetailEntities();
        KaiDataWorkspace.EntityRecord GetRecord();
    }
}
