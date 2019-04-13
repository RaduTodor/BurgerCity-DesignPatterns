using BurgerCity.Services;
using System;
using System.Collections.Generic;

namespace BurgerCity.Contracts
{
    public abstract class AMenu
    {
        protected Guid UniqueId = Guid.NewGuid();
        public List<IMenuItem> Items = new List<IMenuItem>();

        public virtual void AddItem(IMenuItem item)
        {
            Items.Add(item);
            LoggerSingleton.Logger.LogMessage(string.Format("a {0} was added in menu", item.Name()));
        }

        public abstract float GetCost();
        public virtual IEnumerable<string> Display()
        {
            List<string> result = new List<string>();

            foreach (var item in Items)
            {
                result.Add(string.Format("- {0} (on {1}) - {2} RON", item.Name(), item.Packing(), item.Price()));
            }

            return result;
        }

        public virtual Guid GetUniqueId()
        {
            return UniqueId;
        }
    }
}
