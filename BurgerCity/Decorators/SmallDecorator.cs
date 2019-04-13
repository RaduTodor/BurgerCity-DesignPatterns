using BurgerCity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerCity.Decorators
{
    public class SmallDecorator : MenuDecorator
    {
        public SmallDecorator(AMenu baseComponent)
            : base(baseComponent)
        {
            this.Price = base.GetCost();
            this.UniqueId = baseComponent.GetUniqueId();
            this.Items = baseComponent.Items;
        }

        public override float GetCost()
        {
            return Price;
        }
    }
}
