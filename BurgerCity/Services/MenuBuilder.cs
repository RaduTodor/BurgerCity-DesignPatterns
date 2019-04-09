using BurgerCity.Entities;
using BurgerCity.Entities.Packing;

namespace BurgerCity.Services
{
    public class MenuBuilder
    {
        public Menu PrepareBurger(Burger burger, Drink drink)
        {
            Menu menu = new Menu();
            menu.AddItem(burger);
            menu.AddItem(drink);
            return menu;
        }
    }
}
