using BurgerCity.Contracts;
using BurgerCity.Entities;
using BurgerCity.Entities.Enums;
using BurgerCity.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace BurgerCity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MenuBuilder builder = new MenuBuilder();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddToOrder_Click(object sender, RoutedEventArgs e)
        {
            DrinkType drinkType = (DrinkType)Convert.ToInt32(SelectedDrinkType.SelectedValue);
            BurgerType burgerType = (BurgerType)Convert.ToInt32(SelectedBurgerType.SelectedValue);

            IMenuFactory menuFactory = new MenuFactory();

            var menu = builder.PrepareBurger(menuFactory.GetBurger(burgerType), menuFactory.GetDrink(drinkType));
            string content = string.Format("\n{0}. Total Price: {1} RON", OrderList.Items.Count + 1, menu.GetCost());

            foreach (var item in menu.DisplayItems())
            {
                content += "\n";
                content += item;
            }
            OrderList.Items.Add(content);
        }
    }
}
