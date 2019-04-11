using BurgerCity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BurgerCity.Entities
{
    public class Menu : IMenu
    {
        protected List<IMenuItem> Items;
        protected Guid UniqueId;
        public string Content { get { return string.Join("\n", Display()); } }
        public float TotalPrice { get { return GetCost(); } }

        public Menu()
        {
            Items = new List<IMenuItem>();
            UniqueId = Guid.NewGuid();
        }

        public void AddItem(IMenuItem item)
        {
            Items.Add(item);
        }

        public IEnumerable<string> Display()
        {
            List<string> result = new List<string>();

            foreach(var item in Items)
            {
                result.Add(string.Format("- {0} (on {1}) - {2} RON", item.Name(), item.Packing(), item.Price()));
            }

            return result;
        }

        public float GetCost()
        {
            float cost = 0;

            foreach(var item in Items)
            {
                cost += item.Price();
            }

            return cost;
        }

        public Guid GetUniqueId()
        {
            return UniqueId;
        }
    }
}
