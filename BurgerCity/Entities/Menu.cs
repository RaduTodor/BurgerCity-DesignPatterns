using BurgerCity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BurgerCity.Entities
{
    public class Menu : AMenu
    {
        public override float GetCost()
        {
            float cost = 0;

            foreach(var item in Items)
            {
                cost += item.Price();
            }

            return cost;
        }
    }
}
