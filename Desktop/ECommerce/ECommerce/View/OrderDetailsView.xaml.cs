using ECommerce.Models;
using ECommerce.Services;
using System.Windows;

namespace ECommerce.View
{
    /// <summary>
    /// Interaction logic for OrderDetailsView.xaml
    /// </summary>
    public partial class OrderDetailsView
    {
        private readonly OrderDetailService _orderDatailService;
        public List<Order> orders { get; set; }
        public OrderDetailsView()
        {
            InitializeComponent();
            //orders = new List<Order>
            //{
            //    new Order { Id = 1,  Name = "Nimadir", Description = "nimadirlar", Price = 156, },
            //    new Order { Id = 2, Name = "Koptok", Description = "10 lik top", Price = 152, },

            //    new Order { Id = 1,  Name = "Nimadir", Description = "nimadirlar", Price = 156, },
            //    new Order { Id = 2, Name = "Koptok", Description = "10 lik top", Price = 152, },



            //};
            //OrderDetails.Items.Clear();
            //OrderDetails.ItemsSource = orders;
            //Id.Text = "DFVGFDS";
            //FullName.Text = "Aslo kkd";
            //ExpireDate.Text = "xswmoxwsx";
            //TotalPrice.Text = "fgbfd";
            //OrderDate.Text = "fgfedwf";
        }

        public OrderDetailsView(Order order)
        {

        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
            //var window = new OrdersView();
            //window.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }

        private void mButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
    //public class Order
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Description { get; set; }
    //    public double Price { get; set; }
    //    public string ImagePath { get; set; }
    //}
}
