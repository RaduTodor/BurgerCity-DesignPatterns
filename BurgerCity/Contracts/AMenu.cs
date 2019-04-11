using System;
using System.Collections.Generic;

namespace BurgerCity.Contracts
{
    public interface IMenu
    {
        void AddItem(IMenuItem item);
        float GetCost();
        IEnumerable<string> Display();
        Guid GetUniqueId();
    }
}
