using BurgerCity.Contracts;

namespace BurgerCity.Entities.Packing
{
    public class Wrapper: IPacking
    {
        public string Pack()
        {
            return "wrapper";
        }
    }
}
