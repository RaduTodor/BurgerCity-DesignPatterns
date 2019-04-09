using BurgerCity.Contracts;

namespace BurgerCity.Entities.Packing
{
    public abstract class ColdDrink : Drink
    {
        public override string Packing()
        {
            return new Bottle().Pack();
        }
    }
}
