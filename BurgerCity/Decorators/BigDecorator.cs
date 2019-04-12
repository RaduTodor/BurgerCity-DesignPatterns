using BurgerCity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerCity.Decorators
{
    public class BigDecorator : MenuDecorator
    {
        public BigDecorator(AMenu baseComponent)
            : base(baseComponent)
        {
            this.Price = base.GetCost() + 5.0f;
            this.UniqueId = baseComponent.GetUniqueId();
            this.Items = baseComponent.Items;
        }
    }
}
