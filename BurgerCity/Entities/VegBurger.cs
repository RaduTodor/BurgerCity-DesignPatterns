using BurgerCity.Contracts;
using BurgerCity.Entities.Packing;

namespace BurgerCity.Entities
{
    public class VegBurger : Burger
    {
        public override string Name()
        {
            return "Veg Burger";
        }

        public override float Price()
        {
            return 20.0f;
        }
    }
}
