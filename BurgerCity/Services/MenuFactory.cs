using BurgerCity.Contracts;
using BurgerCity.Entities;
using BurgerCity.Entities.Enums;
using BurgerCity.Entities.Packing;

namespace BurgerCity.Services
{
    public class MenuFactory : IMenuFactory
    {
        public Burger GetBurger(BurgerType type)
        {
            switch (type)
            {
                case BurgerType.BEEF:
                    return new BeefBurger();
                case BurgerType.VEG:
                    return new VegBurger();
                default:
                    return null;
            }
        }

        public Drink GetDrink(DrinkType type)
        {
            switch (type)
            {
                case DrinkType.BLACKTEA:
                    return new BlackTea();
                case DrinkType.HOTCOCOA:
                    return new HotCocoa();
                case DrinkType.SPRITE:
                    return new Sprite();
                case DrinkType.COCACOLA:
                    return new CocaCola();
                default:
                    return null;
            }
        }

        public IPacking GetPacking(PackingType type)
        {
            switch (type)
            {
                case PackingType.BOTTLE:
                    return new Bottle();
                case PackingType.CUP:
                    return new Cup();
                case PackingType.WRAPPER:
                default:
                    return new Wrapper();
            }
        }
    }
}
