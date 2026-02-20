using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using MyKai.Data.Attributes;
using kaibasic;
using MyKai.Data.Entities;
using System.Windows.Forms;


namespace MyKai.Data
{
    public static partial class KaiDataWorkspace
    {
        public class EntityRecord
        {
            public IKaiDataEntity Entity;
            public EntityOptions EntityOptions;
            public KaiDataEntityCollection DetailEntities; // Entities having the attribute MasterEntity with Name set to a particular Entity
            public KaiDataControlCollection ManagedControls;
            public string RelativePath;
            public string Subdirectory;

            public EntityRecord()
            {
                DetailEntities = new KaiDataEntityCollection();
                ManagedControls = new KaiDataControlCollection();
            }
        }

        private static readonly Dictionary<string, EntityRecord> entitiyRegistry = new Dictionary<string, EntityRecord> { };
        // The key field of the registry is entity name, so that more entities of the same type can be regietered under different names

        public static KaiDataWorkspaceFindTask Find = new KaiDataWorkspaceFindTask();

        public static void Init()
        {
            CreateAndRegisterEntities();
            AddMasterEntitiesToRegistry();
            AddColumnFieldsToCollectionOfFields();
        }

        public static string WorkspaceRelativePath
        {
            get => MyKai.Properties.MyKaiSettings.Default.kaiDataWorkspaceRelativePath;
        }

        public static void LoadEntities()
        {
            foreach (var record in entitiyRegistry)
            {
                record.Value.Entity.LoadInstances();
            }
        }

        public static void SaveEntities()
        {
            foreach (var records in entitiyRegistry)
            {
                records.Value.Entity.SaveInstances();
            }
        }

        private static void CreateAndRegisterEntities()
        {
            var entityTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsDefined(typeof(KaiDataEntityAttribute)));

            foreach( Type entityType in entityTypes)
            {
                var entityAttributes = entityType.GetCustomAttributes<KaiDataEntityAttribute>();

                foreach(KaiDataEntityAttribute entityAttribute in entityAttributes)
                {
                    if (entityAttribute != null)
                    {
                        IKaiDataEntity newEntity = KaiDataFactory.Produce(entityType);
                        newEntity.EntityName = entityAttribute.EntityName;
                        
                        EntityRecord newRecord = new BuilderOfEntityRecord().WithEntity(newEntity)
                                                                            .WithRelativePath(entityAttribute.RelativePath)
                                                                            .WithSubdirectory(entityAttribute.Subdirectory)
                                                                            .WithEntityOptions(entityAttribute.EntityOptions)
                                                                            .Build();

                        entitiyRegistry.Add(entityAttribute.EntityName, newRecord);
                    }
                }
            }
        }

        private static void AddMasterEntitiesToRegistry()
        {
            foreach(var entityRecord in entitiyRegistry)
            {
                string masterEntityName = entityRecord.Key;
                KaiDataEntityCollection relatedEntities = Find.DetailEntitiesByMasterName(masterEntityName);
                
                foreach(var entity in relatedEntities.Items)
                    entityRecord.Value.DetailEntities.Items.Add(entity);
            }
        }

        private static void AddColumnFieldsToCollectionOfFields()
        {
            foreach(var entityRecord in entitiyRegistry)
            {
                if (entityRecord.Value.Entity.GetType().BaseType == typeof(KaiDataFileStoredEntityBase))
                {
                    Type objectType = entityRecord.Value.Entity.GetObjectType();

                    FieldInfo[] columnFields = objectType.GetFields();
                    
                    foreach (FieldInfo fieldInfo in columnFields)
                    {
                        KaiDataColumnAttribute customAttribute = fieldInfo.GetCustomAttribute<KaiDataColumnAttribute>();

                        if (customAttribute is KaiDataColumnAttribute)
                        {
                            int columnIndex = fieldInfo.GetCustomAttribute<KaiDataColumnAttribute>().Index;
                            KaiDataFileStoredEntityBase fileEntity = (KaiDataFileStoredEntityBase)entityRecord.Value.Entity;
                            fileEntity.Fields.Items.Add( (columnIndex,fieldInfo) );
                        }
                    }
                }
            }
        }
    }
}
