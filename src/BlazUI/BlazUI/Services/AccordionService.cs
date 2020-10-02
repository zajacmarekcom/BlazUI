using BlazUI.Components;
using System.Collections.Generic;

namespace BlazUI.Services
{
    public class AccordionService
    {
        private IList<AccordionItem> Items { get; }

        public delegate void ItemOpened(AccordionItem item);
        public event ItemOpened ItemOpenedHandler;

        public AccordionService()
        {
            Items = new List<AccordionItem>();
        }

        public void AddChild(AccordionItem item)
        {
            Items.Add(item);
        }

        public void OpenAll()
        {
            foreach(var item in Items)
            {
                item.Open();
            }
        }

        public void CloseAll(AccordionItem exceptItem = null)
        {
            foreach(var item in Items)
            {
                if (item == exceptItem) continue;
                item.Close();
            }
        }

        public void Opened(AccordionItem item)
        {
            ItemOpenedHandler?.Invoke(item);
        }
    }
}
