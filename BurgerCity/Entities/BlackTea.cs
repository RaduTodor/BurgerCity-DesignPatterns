using BurgerCity.Entities.Packing;

namespace BurgerCity.Entities
{
    public class BlackTea : HotDrink
    {
        public override string Name()
        {
            return "Black Tea";
        }

        public override float Price()
        {
            return 4.0f;
        }
    }
}
