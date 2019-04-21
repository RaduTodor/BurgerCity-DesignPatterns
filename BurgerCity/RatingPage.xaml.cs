using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Xml;
using BurgerCity.Contracts;
using BurgerCity.Entities;
using BurgerCity.Services;

namespace BurgerCity
{
    /// <summary>
    /// Interaction logic for RatingPage.xaml
    /// </summary>
    public partial class RatingPage : Window
    {
        private ARating _ratingObject = NullRatingObject.Instance;
        public Order RatedOrder { get; set; }

        public RatingPage()
        {
            InitializeComponent();
        }

        private void Rating_Click(object sender, RoutedEventArgs e)
        {
            _ratingObject = new RealRatingObject();
            switch (((Button)sender).Name)
            {
                case "OneStar":
                    _ratingObject.NumberOfStars = 1;
                    break;
                case "TwoStars":
                    _ratingObject.NumberOfStars = 2;
                    break;
                case "ThreeStars":
                    _ratingObject.NumberOfStars = 3;
                    break;
            }
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs cancelEventArgs)
        {
            _ratingObject.Order = RatedOrder;
            _ratingObject.LogRatingValue();
        }
    }
}
