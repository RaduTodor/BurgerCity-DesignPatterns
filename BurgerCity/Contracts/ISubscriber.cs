using BurgerCity.Entities;
using BurgerCity.Entities.Enums;
using System.Collections.Generic;

namespace BurgerCity.Contracts
{
    public interface ISubscriber
    {
        OrderProcess Process { get; set; }
        void Update(List<Order> orders);
    }
}
