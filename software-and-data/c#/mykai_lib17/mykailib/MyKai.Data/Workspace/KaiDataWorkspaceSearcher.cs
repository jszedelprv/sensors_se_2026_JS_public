using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;
using MyKai.Data.Attributes;

namespace MyKai.Data
{
    public abstract class KaiDataSearchTaskBase
    {
        public KaiDataWorkspaceSearcher parent;
        public KaiDataSearchTaskBase(KaiDataWorkspaceSearcher pParent)
        {
            parent = pParent;
        }
    }

    public class KaiDataWorkspaceSearcher
    {
        private readonly Dictionary<string, KaiDataWorkspace.EntityRecord> registryToSearch;

        public  KaiDataWorkspaceSearcher(Dictionary<string, KaiDataWorkspace.EntityRecord> pEntitiyRegistry)
        {
            registryToSearch = pEntitiyRegistry;

            FindEntity = new FindEntityTask(this);
            FindObjects = new FindObjectsTask(this);
            FindObject = new FindObjectTask(this);
            FindRecord = new FindRecordTask(this);
            FindEntities = new FindEntitiesTask(this);
        }

        public FindEntityTask FindEntity;
        public FindObjectsTask FindObjects;
        public FindObjectTask FindObject;
        public FindRecordTask FindRecord;
        public FindEntitiesTask FindEntities;

        public class FindEntityTask : KaiDataSearchTaskBase
        {
            public FindEntityTask(KaiDataWorkspaceSearcher pParent) : base(pParent) {}

            public IKaiDataEntity ByName(string pEntityName)
            {
                try
                {
                    return parent.registryToSearch[pEntityName].Entity;
                }
                catch (KeyNotFoundException e)
                {
                    MessageBox.Show(typeof(KaiDataWorkspace).Name + " : Entity [" + pEntityName + "] not found in data workspace. Program will exit.");
                    Environment.Exit(e.HResult);
                    return null;
                }
            }

            public List<IKaiDataEntity> ByType(Type pType)
            {
                List<IKaiDataEntity> resultEntities = new List<IKaiDataEntity>();

                foreach (KeyValuePair<string, KaiDataWorkspace.EntityRecord> entry in parent.registryToSearch)
                {
                    if (entry.Value.Entity.GetType() == pType)
                        resultEntities.Add(entry.Value.Entity);
                }

                return resultEntities;
            }
        }

        public class FindObjectTask : KaiDataSearchTaskBase
        {
            public FindObjectTask(KaiDataWorkspaceSearcher pParent) : base(pParent) { }

            public KaiDataObjectBase MasterEntitySelectedObject(Type pDeatilEntityType)
            {
                KaiDataMasterEntityAttribute attribute = 
                    (KaiDataMasterEntityAttribute)Attribute.GetCustomAttribute(pDeatilEntityType, typeof(KaiDataMasterEntityAttribute));
               
                IKaiDataEntity masterEntity = KaiDataWorkspace.Find.EntityByName(attribute.MasterEntityName);
                
                return masterEntity.Objects.SelectedObject;
            }
        }

        public class FindObjectsTask : KaiDataSearchTaskBase
        {
            public FindObjectsTask(KaiDataWorkspaceSearcher pParent) : base(pParent) { }
            public KaiDataObjectCollection ByName(string pEntityName)
            {
                return parent.FindEntity.ByName(pEntityName).Objects;
            }
        }

        public class FindRecordTask : KaiDataSearchTaskBase
        {
            public FindRecordTask(KaiDataWorkspaceSearcher pParent) : base(pParent) { }
            public KaiDataWorkspace.EntityRecord ByName(string pName)
            {
                try
                {
                    return parent.registryToSearch[pName];
                }
                catch (KeyNotFoundException e)
                {
                    MessageBox.Show(typeof(KaiDataWorkspace).Name + " : Entity [" + pName + "] record not found in data workspace. Program will exit.");
                    Environment.Exit(e.HResult);
                    return null; // This return instruction is never reached
                }
            }
        }

        public class FindEntitiesTask : KaiDataSearchTaskBase
        {
            public FindEntitiesTask(KaiDataWorkspaceSearcher pParent) : base(pParent) {}

            public KaiDataEntityCollection RelatedByName(string pEntityName)
            {
                var relatedEntityTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsDefined(typeof(KaiDataMasterEntityAttribute)));

                KaiDataEntityCollection resultEntities = new KaiDataEntityCollection();

                foreach (Type entityType in relatedEntityTypes)
                {
                    var entityAttributes = entityType.GetCustomAttributes<KaiDataMasterEntityAttribute>();

                    foreach (var entityAttribute in entityAttributes)
                    {
                        if (entityAttribute.MasterEntityName == pEntityName)
                        {
                            List<IKaiDataEntity> tmpEntities = parent.FindEntity.ByType(entityType);

                            foreach (IKaiDataEntity tmpEntity in tmpEntities)
                                resultEntities.Items.Add(parent.FindEntity.ByName(tmpEntity.EntityName));
                        }
                    }
                }

                return resultEntities;
            }
        }
    }
}
