using ECommerce.Models;
using ECommerce.Services;
using System.Windows;
using System.Windows.Controls;

namespace ECommerce.View
{
    /// <summary>
    /// Interaction logic for OrderDetailsView.xaml
    /// </summary>
    public partial class OrderDetailsView
    {
        private readonly OrderDetailService _orderDatailService;

        public OrderDetailsView(Order order)
        {
            InitializeComponent();
            _orderDatailService = new OrderDetailService();
            var orderDetail = _orderDatailService.GetOrderDetails(order.Id);
            Load(orderDetail);
        }
        private void Load(List<OrderDetail> orderDetail)
        {
            Id.Text = orderDetail[0].Order.Id.ToString();
            FullName.Text = orderDetail[0].Order.Customer.LastName + " " + orderDetail[0].Order.Customer.LastName;
            ExpireDate.Text= orderDetail[0].Order.ExpireDate.ToString();
            OrderDate.Text= orderDetail[0].Order.OrderedDate.ToString();
            double totalPrice = 0;
            List<Product> products = [];
            foreach (OrderDetail detail in orderDetail)
            {
                products.Add(detail.Product);
                totalPrice=+detail.TotalPrice;
            }
            TotalPrice.Text=totalPrice.ToString();
            Products.Items.Clear();
            Products.ItemsSource = products;
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
}
