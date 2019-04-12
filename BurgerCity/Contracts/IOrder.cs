using BurgerCity.Decorators;
using System;
using System.Collections.Generic;

namespace BurgerCity.Contracts
{
    public interface IOrder
    {
        void AddMenu(MenuDecorator menu);
        IDictionary<Guid, string> Display();
        void RemoveMenu(Guid uniqueId);
    }
}
