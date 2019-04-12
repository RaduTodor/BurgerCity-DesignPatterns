using BurgerCity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerCity.Decorators
{
    public class NormalDecorator : MenuDecorator
    {
        public NormalDecorator(AMenu baseComponent)
            : base(baseComponent)
        {
            Price = base.GetCost() + 2.5f;
            UniqueId = baseComponent.GetUniqueId();
            Items = baseComponent.Items;
        }
    }
}
