using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using MyKai.Data.Attributes;
using MyKai.Data.Entities;

namespace MyKai.Data
{
    public abstract class KaiDataEntityBase : IKaiDataEntity
    {
        public string EntityName { get; set; }
        public KaiDataObjectCollection Objects { get; set; }
        public KaiDataFilterCollection Filters { get; set; }
        public KaiDataControlCollection ManagedControls { get; set; }

        public abstract string RelativePath();

        public KaiDataWorkspace.EntityRecord GetRecord() => KaiDataWorkspace.Find.RecordByEntityName(EntityName);

        public KaiDataEntityBase()
        {
            Objects = new KaiDataObjectCollection(this);
            Filters = new KaiDataFilterCollection();
            ManagedControls = new KaiDataControlCollection(this);
        }

        public void RefreshDetailEntities()
        {
            KaiDataEntityCollection detailEntities = KaiDataWorkspace.Find.DetailEntitiesByMasterName(EntityName);

            foreach (IKaiDataEntity detailEntity in detailEntities.Items)
            {
                if (detailEntity.GetRecord().EntityOptions.HasFlag(EntityOptions.DeserializeOnRefresh))
                    detailEntity.LoadInstances();
            }
        }

        public void LoadInstances()
        {
            Objects.Items.Clear();
            
            Deserialize();
            Filter();

            ManagedControls.ReloadListItems();
            Objects.SelectFirst();       
        }

        public void SaveInstances()
        {
            Serialize();
        }

        public virtual void DeleteInstances(KaiDataObjectCollection pInstancesToDel) { }

        protected abstract void Deserialize();

        protected virtual void Serialize()
        {
            throw new NotImplementedException( GetType().Name +" : Not a saveable entity " + GetType().Name + ".");
        }

        protected void Filter()
        {
            if (Filters.Items.Count == 0) 
                return;

            KaiDataObjectCollection filteredCollection = new KaiDataObjectCollection(this);

            foreach( KaiDataObjectBase checkedObject in Objects.Items)
            {
                if (Filters.CheckAll(checkedObject))
                    filteredCollection.Items.Add(checkedObject);
            }

            Objects = filteredCollection;
        }

        public abstract Type GetObjectType();
        public abstract KaiDataObjectBase GetNewObject();
    } 
}
