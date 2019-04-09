using BurgerCity.Entities.Enums;
using BurgerCity.Services;

namespace BurgerCity.Entities.Packing
{
    public abstract class ColdDrink : Drink
    {
        public override string Packing()
        {
            return new MenuFactory().GetPacking(PackingType.BOTTLE).Pack();
        }
    }
}
