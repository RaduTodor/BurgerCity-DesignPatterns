using BurgerCity.Contracts;

namespace BurgerCity.Entities.Packing
{
    public abstract class Drink : IMenuItem
    {
        public abstract string Name();
        public abstract float Price();
        public abstract string Packing();
    }
}
