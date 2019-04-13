using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BurgerCity.Contracts;
using BurgerCity.Services;

namespace BurgerCity
{
    /// <summary>
    /// Interaction logic for FinalizeOrderWindow.xaml
    /// </summary>
    public partial class FinalizeOrderWindow : Window
    {
        public float OrderPrice { get; set; }
        private IAccount CurrentAccount { get; set; }
        public MainWindow MainWindow { get; set; }

        public FinalizeOrderWindow()
        {
            InitializeComponent();
            AccountProxy = new PointsAccountProxy();
        }

        private PointsAccountProxy AccountProxy { get; set; }

        private void AuthenticateButton_OnClick(object sender, RoutedEventArgs e)
        {
            CurrentAccount = AccountProxy.ChangeAccount(this.AccountCodeTextBox.Text);
            this.AccountPointsLabel.Content = $"You currently have {CurrentAccount.GetPointsAmount()} points";
            this.PayFinalizeButton.IsEnabled = true;
            this.PointsFinalizeButton.IsEnabled = CurrentAccount.IsEnough(Convert.ToInt32(OrderPrice));
        }

        private void PayFinalizeButton_OnClick(object sender, RoutedEventArgs e)
        {
            CurrentAccount.AddPoints(Convert.ToInt32(OrderPrice)/10);
            AccountProxy.SaveChanges();
            this.Close();
        }

        private void PointsFinalizeButton_OnClick(object sender, RoutedEventArgs e)
        {
            CurrentAccount.RemovePoints(Convert.ToInt32(OrderPrice));
            AccountProxy.SaveChanges();
            this.Close();
        }

        private void CancelOrder_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.OrderCanceled = true;
            this.Close();
        }
    }
}
