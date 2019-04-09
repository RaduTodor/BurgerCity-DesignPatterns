using BurgerCity.Contracts;

namespace BurgerCity.Entities.Packing
{
    public abstract class Burger : IMenuItem
    {
        public abstract string Name();
        public abstract float Price();

        public string Packing()
        {
            return new Wrapper().Pack();
        }
    }
}
