
using System.Collections.Generic;

namespace MyKai.Data
{
    public class KaiDataObjectCollection
    {
        private KaiDataEntityBase entity;

        public KaiDataObjectBase SelectedObject = null;

        public KaiDataObjectCollection(KaiDataEntityBase pEntity)
        {
            entity = pEntity;
            Items = new List<KaiDataObjectBase>();
        }

        public List<KaiDataObjectBase> Items;

        public void SelectFirst()
        {
            if (Items.Count > 0)
                SelectedObject = Items[0];

            entity.ManagedControls.SelectFirstItem();
        }

        public KaiDataObjectBase ObjectByName(string pName)
        {
            return Items.Find(x => x.Name == pName);
        }

        public KaiDataObjectBase SelectObjectByName(string pName)
        {
            return SelectedObject = Items.Find(x => x.Name == pName);
        }
    }
}
