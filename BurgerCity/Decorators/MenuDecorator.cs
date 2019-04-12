using BurgerCity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerCity.Decorators
{
    public abstract class MenuDecorator : AMenu
    {
        AMenu baseComponent = null;

        protected float Price = 0.0f;
        public string TotalPrice { get { return Price.ToString(); } }
        public string Content { get { return string.Join("\n", baseComponent.Display()); } }

        protected MenuDecorator(AMenu menu)
        {
            baseComponent = menu;
        }

        public override float GetCost()
        {
            return Price + baseComponent.GetCost();
        }
    }
}
