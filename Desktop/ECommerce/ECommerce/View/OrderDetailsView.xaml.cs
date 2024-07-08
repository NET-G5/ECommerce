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
        public List<OrderDetail> _orderDetails;

        public OrderDetailsView(Order order)
        {
            InitializeComponent();

            _orderDatailService = new();
            _orderDetails = _orderDatailService.GetOrderDetails(order.Id);

            var data=RefreshData(_orderDetails);
            Products.ItemsSource = null;
            Products.ItemsSource = data;
        }

        

        private List<Product> RefreshData(List<OrderDetail> orderDetails)
        {
            Id.Text = orderDetails[0].Order.Id.ToString();
            FullName.Text = orderDetails[0].Order.Customer.ToString();
            ExpireDate.Text = orderDetails[0].Order.ExpireDate.ToString("dd/MM/yyyy HH:mm");
            OrderDate.Text = orderDetails[0].Order.OrderedDate.ToString("dd/MM/yyyy HH:mm");
            var products = new List<Product>();
            var totalPrice = 0d;
            foreach (var detail in orderDetails)
            {
                products.Add(detail.Product);
                totalPrice += detail.Product.Price;
            }
            TotalPrice.Text = totalPrice.ToString() + " so'm";
            return products;

        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void OrderSale_Click(object sender, RoutedEventArgs e)
        {

            OrderSale_Button.Visibility = Visibility.Collapsed;
            OrderCancel_Button.Content = "Refund";
        }

        private void OrderCancel_Click(object sender, RoutedEventArgs e)
        {
            if (OrderCancel_Button.Content == "Refund")
            {
                return;
            }
            OrderCancel_Button.Visibility = Visibility.Collapsed;
            OrderSale_Button.Visibility = Visibility.Collapsed;

        }

        private void ProductCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Epladim :)","Success",MessageBoxButton.OK,MessageBoxImage.Question);
        } 
        private void ProductSale_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Epladim :)","Success",MessageBoxButton.OK,MessageBoxImage.Question);
        }
        private void ProductRefund_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Epladim :)","Success",MessageBoxButton.OK,MessageBoxImage.Question);
        }

    }
}
