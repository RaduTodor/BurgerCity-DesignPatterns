using BurgerCity.Contracts;
using BurgerCity.Entities;
using BurgerCity.Entities.Enums;
using BurgerCity.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BurgerCity
{
    

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MenuBuilder builder = new MenuBuilder();
        private int OrderIndex = 1;
        private Order currentOrder = new Order(1);
        private static IOrderQueue AllOrders = new OrderQueue();

        private Subscriber waitingListOrders = new Subscriber { Process = OrderProcess.OnWaitingList };
        private Subscriber inProgressOrders = new Subscriber { Process = OrderProcess.InProgress };
        private Subscriber readyOrders = new Subscriber { Process = OrderProcess.Ready };

        private bool canFinalizeCurrentOrder = false;
        public bool OrderCanceled { get; set; }

        private void OnTick(object source, System.Timers.ElapsedEventArgs e)
        {
            AllOrders.Upgrade();
            this.Dispatcher.Invoke(() =>
            {
                ReinitOrderQueueSource();
            });
        }

        public MainWindow()
        {
            InitializeComponent();
            OrderContent.ItemsSource = currentOrder.Menus;
            FinalizeOrderBtn.Visibility = Visibility.Hidden;
            AllOrders.Subscribe(waitingListOrders);
            AllOrders.Subscribe(inProgressOrders);
            AllOrders.Subscribe(readyOrders);

            WaitingList.ItemsSource = waitingListOrders.SpecificOrders;
            InProgress.ItemsSource = inProgressOrders.SpecificOrders;
            Ready.ItemsSource = readyOrders.SpecificOrders;

            Random rnd = new Random();
            var timer = new System.Timers.Timer(rnd.Next(3000, 10000));
            timer.Elapsed += OnTick;

            timer.Start();
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
            WaitingList.ItemsSource = null;
            InProgress.ItemsSource = null;
            Ready.ItemsSource = null;

            WaitingList.ItemsSource = waitingListOrders.SpecificOrders;
            InProgress.ItemsSource = inProgressOrders.SpecificOrders;
            Ready.ItemsSource = readyOrders.SpecificOrders;
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            AMenu selectedMenu = OrderContent.SelectedItem as AMenu;
            currentOrder.RemoveMenu(selectedMenu.GetUniqueId());
            ReinitOrderSource();
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
            FinalizeOrderWindow finalizeOrderWindow = new FinalizeOrderWindow();
            finalizeOrderWindow.Visibility = Visibility.Visible;
            finalizeOrderWindow.OrderPrice = currentOrder.TotalPrice;
            finalizeOrderWindow.MainWindow = this;
            OrderCanceled = false;
            finalizeOrderWindow.ShowDialog();

            if (!this.OrderCanceled)
            {
                AllOrders.AddOrder(currentOrder);
                currentOrder = new Order(++OrderIndex);
                ReinitOrderSource();
                ReinitOrderQueueSource();
            }
        }

        private void Ready_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AllOrders.RemoveOrder((Order)((ListBox)sender).SelectedItem);
            RatingPage ratingPage = new RatingPage();
            ratingPage.RatedOrder = (Order)((ListBox)sender).SelectedItem;
            ratingPage.Show();
            ReinitOrderQueueSource();
        }
    }
}
