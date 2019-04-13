using BurgerCity.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BurgerCity.Entities
{
    public class OrderQueue : IOrderQueue
    {
        private List<ISubscriber> _subscribers;
        public List<Order> _orderList;

        public OrderQueue()
        {
            _subscribers = new List<ISubscriber>();
            _orderList = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            _orderList.Add(order);
            Notify(_orderList);
        }

        public void Notify(List<Order> orders)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(orders);
            }
        }

        public List<Order> QueueContent()
        {
            return _orderList;
        }

        public bool Subscribe(ISubscriber subscriber)
        {
            if (_subscribers.Contains(subscriber))
            {
                return false;
            }
            _subscribers.Add(subscriber);
            return true;
        }

        public bool UnSubscribe(ISubscriber subscriber)
        {
            if (!_subscribers.Contains(subscriber))
            {
                return false;
            }
            _subscribers.Remove(subscriber);
            return true;
        }

        public void Upgrade()
        {
            var updatedList = new List<Order>();
            foreach(var order in _orderList)
            {
                order.Upgrade();
                updatedList.Add(order);
            }
            Notify(updatedList);
        }
    }
}
