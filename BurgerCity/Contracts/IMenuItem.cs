using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerCity.Contracts
{
    public interface IMenuItem
    {
        string Name();
        string Packing();
        float Price();
    }
}
