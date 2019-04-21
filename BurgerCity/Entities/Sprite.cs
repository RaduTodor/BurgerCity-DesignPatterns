using BurgerCity.Entities.Packing;

namespace BurgerCity.Entities
{
    public class Sprite : ColdDrink
    {
        public override string Name()
        {
            return "Sprite";
        }

        public override float Price()
        {
            return 5.0f;
        }
    }
}
