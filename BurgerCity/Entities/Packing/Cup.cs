using BurgerCity.Contracts;

namespace BurgerCity.Entities.Packing
{
    public class Cup: IPacking
    {
        public string Pack()
        {
            return "Cup";
        }
    }
}
