using System;
using System.Windows.Forms;
using System.Collections.Generic;


namespace MyKai.Data
{
    public class KaiDataControlCollection
    {
        private KaiDataEntityBase entity;

        public List<Control> Items;

        public KaiDataControlCollection()
        {
            Items = new List<Control>();
        }

        public KaiDataControlCollection(KaiDataEntityBase pEntity)
        {
            entity = pEntity;
            Items = new List<Control>();
        }

        private delegate void ActionOnControls(Control pControl);

        private void MakeActionOnControls(ActionOnControls pAction)
        {
            foreach (Control control in Items)
            {
                pAction(control);
            }
        }

        private delegate void ActionOnControlsAndObjects(Control pControl, KaiDataObjectBase pObject);

        private void MakeActionOnControlsAndObjects(ActionOnControlsAndObjects pAction)
        {
            foreach (Control control in Items)
            {
                foreach (KaiDataObjectBase _object in entity.Objects.Items)
                {
                    pAction(control, _object);
                }
            }
        }

        private void AddListItemAction(Control pControl, KaiDataObjectBase pObject)
        {
            if (IsControlA<ComboBox>(pControl))
            {
                ComboBox cb = (ComboBox)pControl;
                cb.Items.Add(pObject.Name);
            }
                
            if (IsControlA<ListBox>(pControl))
            {
                ListBox lb = (ListBox)pControl;
                lb.Items.Add(pObject.Name);
            }
        }

        private void ClearListAction(Control pControl)
        {
            if (IsControlA<ComboBox>(pControl))
            {
                ComboBox cb = (ComboBox)pControl;
                cb.Items.Clear();
            }

            if (IsControlA<ListBox>(pControl))
            {
                ListBox lb = (ListBox)pControl;
                lb.Items.Clear();
            }
        }
        private void SelectFirstItemAction(Control pControl)
        {
            if (IsControlBaseA<ListControl>(pControl))
            {
                ListControl lc = (ListControl)pControl;
                try
                {
                    lc.SelectedIndex = 0;
                }
                catch (Exception)
                {
                }
            }
        }

        private void ClearListItems()
        {
            MakeActionOnControls(ClearListAction);
        }

        public void ReloadListItems()
        {
            ClearListItems();
            MakeActionOnControlsAndObjects(AddListItemAction);
            SelectFirstItem();
        }

        public void SelectFirstItem()
        {
            MakeActionOnControls(SelectFirstItemAction);
        }

        private bool IsControlA<T>(Control pControl) where T : Control => pControl.GetType() == typeof(T);
        private bool IsControlBaseA<T>(Control pControl) where T : Control => pControl.GetType().BaseType == typeof(T);
    }
}