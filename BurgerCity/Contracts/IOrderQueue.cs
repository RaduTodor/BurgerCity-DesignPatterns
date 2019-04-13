using BurgerCity.Entities;
using System.Collections.Generic;

namespace BurgerCity.Contracts
{
    public interface IOrderQueue
    {
        bool Subscribe(ISubscriber subscriber);
        bool UnSubscribe(ISubscriber subscriber);
        void Notify(List<Order> orders);
        void AddOrder(Order order);
        void RemoveOrder(Order order);
        void Upgrade();
        List<Order> QueueContent();
    }
}
