using ECommerce.Models;
using ECommerce.Services;
using System.ComponentModel;
using System.Windows;

namespace ECommerce.View
{
    /// <summary>
    /// Interaction logic for OrderDetailsView.xaml
    /// </summary>
    public partial class OrderDetailsView : Window, INotifyPropertyChanged
    {
        private readonly OrderDetailService _orderDetailService;
        public List<OrderDetail> _orderDetails;

        private bool _isButtonVisible;

        public bool IsButtonVisible
        {
            get => _isButtonVisible;
            set
            {
                _isButtonVisible = value;
                OnPropertyChanged(nameof(IsButtonVisible));
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public OrderDetailsView(Order order)
        {
            InitializeComponent();

            _orderDetailService = new();
            _orderDetails = _orderDetailService.GetOrderDetails(order.Id);

            var data = RefreshData(_orderDetails);
            Products.ItemsSource = null;
            Products.ItemsSource = data;
        }



        private List<Product> RefreshData(List<OrderDetail> orderDetails)
        {
            if (orderDetails.Count == 0)
            {
                MessageBox.Show("order not found", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return new();
            }
            IdInput.Text = orderDetails[0].Order.Id.ToString();

            FullName.Text = orderDetails[0].Order.Customer.ToString();
            ExpireDate.Text = orderDetails[0].Order.ExpireDate.ToString("dd/MMM/yyyy");
            OrderDate.Text = orderDetails[0].Order.OrderedDate.ToString("dd/MMM/yyyy");
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
            var result = MessageBox.Show("Are you sure you want to exit the program?", "Ecommerce", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
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
            MessageBox.Show("Epladim :)", "Success", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        private void ProductSale_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Epladim :)", "Success", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        private void ProductRefund_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Epladim :)", "Success", MessageBoxButton.OK, MessageBoxImage.Question);
        }

    }
}
