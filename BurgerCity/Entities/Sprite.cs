using BurgerCity.Entities.Packing;

namespace BurgerCity.Entities
{
    public class CocaCola : ColdDrink
    {
        public override string Name()
        {
            return "Coca Cola";
        }

        public override float Price()
        {
            return 5.0f;
        }
    }
}
