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
        private int OrderIndex = 0;
        private Order currentOrder = new Order(0);
        private List<Order> orderQueue = new List<Order>();
        private bool canFinalizeCurrentOrder = false;

        public MainWindow()
        {
            InitializeComponent();
            OrderContent.ItemsSource = currentOrder.Menus;
            OrderList.ItemsSource = orderQueue;
            FinalizeOrderBtn.Visibility = Visibility.Hidden;
        }

        private void ReinitOrderSource()
        {
            OrderContent.ItemsSource = null;
            OrderContent.ItemsSource = currentOrder.Menus;
            canFinalizeCurrentOrder = currentOrder.Menus.Count > 0;
            FinalizeOrderBtn.Visibility = canFinalizeCurrentOrder ? Visibility.Visible : Visibility.Hidden;
        }

        private void ReinitOrderQueueSource()
        {
            OrderList.ItemsSource = null;
            OrderList.ItemsSource = orderQueue;
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            AMenu selectedMenu = OrderContent.SelectedItem as AMenu;
            currentOrder.RemoveMenu(selectedMenu.GetUniqueId());
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

            currentOrder.AddMenu(menu);

            ReinitOrderSource();
        }

        private void SubmitOrder_Click(object sender, RoutedEventArgs e)
        {
            orderQueue.Add(currentOrder);
            currentOrder = new Order(++OrderIndex);
            ReinitOrderSource();
            ReinitOrderQueueSource();
        }
    }
}
