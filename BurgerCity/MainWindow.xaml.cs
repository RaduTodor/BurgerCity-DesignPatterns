using BurgerCity.Entities;
using BurgerCity.Services;
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

        private void VegWithCola_Click(object sender, RoutedEventArgs e)
        {
            var menu = builder.PrepareBurger(new VegBurger(), new CocaCola());
            string content = "";
            foreach (var item in menu.DisplayItems())
            {
                content += " ";
                content += item;
            }
            OrderList.Items.Add(content);
        }

        private void VegWithSprite_Click(object sender, RoutedEventArgs e)
        {
            var menu = builder.PrepareBurger(new VegBurger(), new Sprite());
            string content = "";
            foreach (var item in menu.DisplayItems())
            {
                content += " ";
                content += item;
            }
            OrderList.Items.Add(content);

        }
    }
}
