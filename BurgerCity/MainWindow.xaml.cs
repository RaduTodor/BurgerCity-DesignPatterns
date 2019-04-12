using BurgerCity.Contracts;
using BurgerCity.Decorators;
using BurgerCity.Entities;
using BurgerCity.Entities.Enums;
using BurgerCity.Services;
using System;
using System.Collections.Generic;
using System.Windows;

namespace BurgerCity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MenuBuilder builder = new MenuBuilder();
        private Order order = new Order();
        
        public MainWindow()
        {
            InitializeComponent();
            OrderContent.ItemsSource = order.Menus;
        }

        private void ReinitOrderSource()
        {
            OrderContent.ItemsSource = null;
            OrderContent.ItemsSource = order.Menus;
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            AMenu selectedMenu = OrderContent.SelectedItem as AMenu;
            order.RemoveMenu(selectedMenu.GetUniqueId());
            ReinitOrderSource();
            MessageBox.Show("Menu Deleted Successfully");
        }

        private void AddToOrder_Click(object sender, RoutedEventArgs e)
        {
            DrinkType drinkType = (DrinkType)Convert.ToInt32(SelectedDrinkType.SelectedValue);
            BurgerType burgerType = (BurgerType)Convert.ToInt32(SelectedBurgerType.SelectedValue);
            MenuSize menuSize = (MenuSize)Convert.ToInt32(SelectedMenuSize.SelectedValue);

            IMenuFactory menuFactory = new MenuFactory();

            var menu = builder.PrepareBurger(menuFactory.GetBurger(burgerType), menuFactory.GetDrink(drinkType), menuSize);

            order.AddMenu(menu);

            
            ReinitOrderSource();
        }
    }
}
