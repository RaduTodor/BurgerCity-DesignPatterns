using BurgerCity.Entities.Enums;
using BurgerCity.Entities.Packing;

namespace BurgerCity.Contracts
{
    public interface IMenuFactory
    {
        IPacking GetPacking(PackingType type);
        Burger GetBurger(BurgerType type);
        Drink GetDrink(DrinkType type);
    }
}
