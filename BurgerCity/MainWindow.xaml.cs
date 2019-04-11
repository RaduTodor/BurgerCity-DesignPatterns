﻿using BurgerCity.Contracts;
using BurgerCity.Entities;
using BurgerCity.Entities.Enums;
using BurgerCity.Services;
using System;
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
            IMenu selectedMenu = OrderContent.SelectedItem as IMenu;
            order.RemoveMenu(selectedMenu.GetUniqueId());
            ReinitOrderSource();
            MessageBox.Show("Menu Deleted Successfully");
        }

        private void AddToOrder_Click(object sender, RoutedEventArgs e)
        {
            DrinkType drinkType = (DrinkType)Convert.ToInt32(SelectedDrinkType.SelectedValue);
            BurgerType burgerType = (BurgerType)Convert.ToInt32(SelectedBurgerType.SelectedValue);

            IMenuFactory menuFactory = new MenuFactory();

            var menu = builder.PrepareBurger(menuFactory.GetBurger(burgerType), menuFactory.GetDrink(drinkType));
            MenuSize menuSize = (MenuSize)Convert.ToInt32(SelectedMenuSize.SelectedValue);

            order.AddMenu(menu);
            
            ReinitOrderSource();
        }
    }
}
