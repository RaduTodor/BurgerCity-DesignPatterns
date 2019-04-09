using BurgerCity.Contracts;
using BurgerCity.Entities.Enums;
using BurgerCity.Services;

namespace BurgerCity.Entities.Packing
{
    public abstract class Burger : IMenuItem
    {
        public abstract string Name();
        public abstract float Price();

        public string Packing()
        {
            return new MenuFactory().GetPacking(PackingType.WRAPPER).Pack();
        }
    }
}
