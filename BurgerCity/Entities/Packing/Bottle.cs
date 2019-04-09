using BurgerCity.Contracts;

namespace BurgerCity.Entities.Packing
{
    public class Bottle: IPacking
    {
        public string Pack()
        {
            return "bottle";
        }
    }
}
