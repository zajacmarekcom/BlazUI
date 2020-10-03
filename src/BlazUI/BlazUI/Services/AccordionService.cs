using BlazUI.Components;
using System.Collections.Generic;

namespace BlazUI.Services
{
    public class AccordionService
    {
        private IList<AccordionItem> Items { get; }
        private bool AlwaysOpen { get; }

        public delegate void ItemOpened(AccordionItem item);
        public event ItemOpened ItemOpenedHandler;

        public AccordionService(bool alwaysOpen = false)
        {
            Items = new List<AccordionItem>();
            AlwaysOpen = alwaysOpen;
        }

        public void AddChild(AccordionItem item)
        {
            Items.Add(item);
            if (AlwaysOpen)
            {
                item.Open();
            }
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
