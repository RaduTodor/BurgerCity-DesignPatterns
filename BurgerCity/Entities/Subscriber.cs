using BurgerCity.Contracts;
using BurgerCity.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BurgerCity.Entities
{
    public class Subscriber: ISubscriber
    {
        public OrderProcess Process { get; set; }
        public List<Order> SpecificOrders { get; set; }

        public void Update(List<Order> orders)
        {
            switch (Process)
            {
                case OrderProcess.OnWaitingList:
                    SpecificOrders = orders.Where(x => x.Process == OrderProcess.OnWaitingList).ToList();
                    break;
                case OrderProcess.InProgress:
                    SpecificOrders = orders.Where(x => x.Process == OrderProcess.InProgress).ToList();
                    break;
                case OrderProcess.Ready:
                    SpecificOrders = orders.Where(x => x.Process == OrderProcess.Ready).ToList();
                    break;
            }
        }
    }
}
