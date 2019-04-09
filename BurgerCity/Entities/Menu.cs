using BurgerCity.Contracts;
using System.Collections.Generic;
using System.Linq;
namespace BurgerCity.Entities
{
    public class Menu : IMenu
    {
        public List<IMenuItem> Items => new List<IMenuItem>();

        public void AddItem(IMenuItem item)
        {
            Items.Add(item);
        }

        public IEnumerable<string> DisplayItems()
        {
            for(int i = 0; i < Items.Count(); i++)
            {
                IMenuItem item = Items.ElementAt(i);
                yield return string.Format("{0}. {1} (on {2}) - {3}", i, item.Name(), item.Packing(), item.Price());
            }
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
    }
}
