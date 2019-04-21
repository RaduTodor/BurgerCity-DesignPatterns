using BurgerCity.Contracts;
using BurgerCity.Decorators;
using BurgerCity.Entities.Enums;
using BurgerCity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

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
            LoggerSingleton.Logger.LogMessage(string.Format("Menu (id:{0}) was added in the order (id: {1}). Menu cost:{2} and was composed of {3}", menu.GetUniqueId(), UniqueKey, menu.TotalPrice, menu.Content));

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
            TotalPrice -= toBeRemoved.GetCost();
            LoggerSingleton.Logger.LogMessage(string.Format("Menu (id:{0}) was removed from the order (id: {1}). Menu cost:{2} and was composed of {3}", toBeRemoved.GetUniqueId(), UniqueKey, toBeRemoved.TotalPrice, toBeRemoved.Content));
        }

        public void Upgrade()
        {
            switch (Process)
            {
                case OrderProcess.OnWaitingList:
                    Process = OrderProcess.InProgress;
                    break;
                case OrderProcess.InProgress:
                    Process = OrderProcess.Ready;
                    break;
            }
        }
    }
}
