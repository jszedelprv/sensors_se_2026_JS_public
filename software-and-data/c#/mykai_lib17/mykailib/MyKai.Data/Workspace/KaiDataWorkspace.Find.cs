
using System;
using System.Collections.Generic;
using MyKai.Data;
using MyKai.Data.Entities;


namespace MyKai.Data
{
    public static partial class KaiDataWorkspace
    {
        public class KaiDataWorkspaceFindTask
        { 
            private static readonly KaiDataWorkspaceSearcher registrySearcher = new KaiDataWorkspaceSearcher(entitiyRegistry);

            public IKaiDataEntity EntityByName(string pEntityName)
                => registrySearcher.FindEntity.ByName(pEntityName);

            public KaiDataObjectCollection ObjectsByEntityName(string pEntityName)
                => registrySearcher.FindObjects.ByName(pEntityName);

            public KaiDataEntityCollection DetailEntitiesByMasterName(string pMasterEntityName)
                => registrySearcher.FindEntities.RelatedByName(pMasterEntityName);

            public KaiDataWorkspace.EntityRecord RecordByEntityName(string pEntityName)
                => registrySearcher.FindRecord.ByName(pEntityName);

            public KaiDataObjectBase MasterEntitySelectedObjectByType(Type pDetailEntityType) 
                => registrySearcher.FindObject.MasterEntitySelectedObject(pDetailEntityType);
        }
    }
}