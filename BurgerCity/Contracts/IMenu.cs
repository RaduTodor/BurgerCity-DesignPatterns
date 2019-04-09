using System.Collections.Generic;

namespace BurgerCity.Contracts
{
    public interface IMenu
    {
        void AddItem(IMenuItem item);
        float GetCost();
        IEnumerable<string> DisplayItems();
    }
}
