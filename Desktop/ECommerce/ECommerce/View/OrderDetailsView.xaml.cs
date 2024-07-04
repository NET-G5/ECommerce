using ECommerce.Models;
using System.Windows;
using System.Windows.Controls;

namespace ECommerce.View
{
    /// <summary>
    /// Interaction logic for OrderDetailsView.xaml
    /// </summary>
    public partial class OrderDetailsView
    {
        private List<Order> orders;
        public OrderDetailsView()
        {
            InitializeComponent();
            orders = new List<Order>
            {
                new Order { Id = 1,  Name = "Nimadir", Description = "nimadirlar", Price = 156, },
                new Order { Id = 2, Name = "Koptok", Description = "10 lik top", Price = 152, }
            };

            OrderDetails.ItemsSource = orders;
        }
        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
    }
}
