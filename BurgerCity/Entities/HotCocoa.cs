using BurgerCity.Entities.Packing;

namespace BurgerCity.Entities
{
    public class HotCocoa : HotDrink
    {
        public override string Name()
        {
            return "Hot Cocoa";
        }

        public override float Price()
        {
            return 9.0f;
        }
    }
}
