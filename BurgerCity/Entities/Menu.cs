using BurgerCity.Contracts;
using System.Collections.Generic;
using System.Linq;
namespace BurgerCity.Entities
{
    public class Menu : IMenu
    {
        public List<IMenuItem> Items;

        public Menu()
        {
            Items = new List<IMenuItem>();
        }

        public void AddItem(IMenuItem item)
        {
            Items.Add(item);
        }

        public IEnumerable<string> DisplayItems()
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
    }
}
