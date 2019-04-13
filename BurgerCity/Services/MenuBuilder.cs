using BurgerCity.Contracts;
using BurgerCity.Decorators;
using BurgerCity.Entities;
using BurgerCity.Entities.Enums;
using BurgerCity.Entities.Packing;
using System;

namespace BurgerCity.Services
{
    public class MenuBuilder
    {
        public MenuDecorator PrepareBurger(Burger burger, Drink drink, MenuSize menuSize)
        {
            try
            {
                Menu menu = new Menu();
                menu.AddItem(burger);
                menu.AddItem(drink);

                switch (menuSize)
                {
                    case MenuSize.SMALL:
                    default:
                        return new SmallDecorator(menu);
                    case MenuSize.NORMAL:
                        return new NormalDecorator(menu);
                    case MenuSize.BIG:
                        return new BigDecorator(menu);
                }
            }
            catch(Exception e)
            {
                LoggerSingleton.Logger.LogError(e);
                return null;
            }
        }
    }
}
