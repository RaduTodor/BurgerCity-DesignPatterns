using BurgerCity.Contracts;

namespace BurgerCity.Entities.Packing
{
    public abstract class HotDrink : Drink
    {
        public override string Packing()
        {
            return new Cup().Pack();
        }
    }
}
