using BurgerCity.Entities.Packing;

namespace BurgerCity.Entities
{
    public class BeefBurger : Burger
    {
        public override string Name()
        {
            return "Beef Burger";
        }

        public override float Price()
        {
            return 40.0f;
        }
    }
}
