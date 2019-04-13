using BurgerCity.Contracts;
using BurgerCity.Decorators;
using BurgerCity.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BurgerCity.Entities
{
    public class Order : IOrder
    {
        public List<MenuDecorator> Menus { get; private set; }
        public float TotalPrice { get; set; } = 0.0f;
        public int UniqueKey { get; set; }
        public OrderProcess Process { get; set; } = OrderProcess.OnWaitingList;

        public Order(int key)
        {
            Menus = new List<MenuDecorator>();
            UniqueKey = key;
        }

        public void AddMenu(MenuDecorator menu)
        {
            Menus.Add(menu);
            TotalPrice += menu.GetCost();
        }

        public IDictionary<Guid, string> Display()
        {
            Dictionary<Guid, string> result = new Dictionary<Guid, string>();
            

            for(var i = 0; i < Menus.Count; i++)
            {
                var menu = Menus.ElementAt(i);
                string content = string.Format("\n{0}. Total Price: {1} RON\n", i + 1, menu.GetCost());
                content += Menus[i].Display();
                result.Add(menu.GetUniqueId(), content);
            }

            return result;
        }

        public void RemoveMenu(Guid uniqueId)
        {
            var toBeRemoved = Menus.Where(x => x.GetUniqueId() == uniqueId).FirstOrDefault();
            Menus.Remove(toBeRemoved);
        }
    }
}
