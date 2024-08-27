using ECommerce.Models;
using ECommerce.Services;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ECommerce.View
{
    /// <summary>
    /// Interaction logic for OrderDetailsView.xaml
    /// </summary>

    public partial class OrderDetailsView : Window, INotifyPropertyChanged
    {
        private readonly OrderDetailService _orderDetailService;
        public List<OrderDetail> _orderDetails;
        public event PropertyChangedEventHandler? PropertyChanged;
        public List<Product> _products;

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

     

        public OrderDetailsView(Order order)
        {
            InitializeComponent();

            _orderDetailService = new();
            _orderDetails = _orderDetailService.GetOrderDetails(order.Id);

            _products= RefreshData(_orderDetails);
            Products.ItemsSource = null;
            Products.ItemsSource = _products;
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
            var selectedItem = Products.SelectedItem as Product;
            var button = sender as Button;
            var dataGridRow = button.Tag as DataGridRow;

            if (dataGridRow != null)
            {
                var button1 = FindVisualChild<Button>(dataGridRow, "CancelButton");
                var button2 = FindVisualChild<Button>(dataGridRow, "RefundButton");
                var button3 = FindVisualChild<Button>(dataGridRow, "SaleButton");

                if (button1 != null)
                {
                    var product=_products.FirstOrDefault(x => x.Id == selectedItem.Id);


                    button1.Visibility = Visibility.Collapsed;
                }

                if (button2 != null)
                {
                    button2.Visibility = Visibility.Collapsed;
                }

                if (button3 != null)
                {
                    button3.Visibility = Visibility.Collapsed;
                }
            }
            
        }
        private void ProductSale_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var dataGridRow = button.Tag as DataGridRow;

            if (dataGridRow != null)
            {
                var button1 = FindVisualChild<Button>(dataGridRow, "RefundButton");
                var button2 = FindVisualChild<Button>(dataGridRow, "SaleButton");
                var button3 = FindVisualChild<Button>(dataGridRow, "CancelButton");

                if (button1 != null)
                {
                    button1.Visibility = Visibility.Visible;
                }

                if (button2 != null)
                {
                    button2.Visibility = Visibility.Collapsed;
                }
                if (button3 != null)
                {
                    button3.Visibility = Visibility.Collapsed;
                }

            }
        }
        private T FindVisualChild<T>(DependencyObject parent, string name) where T : FrameworkElement
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T frameworkElement && frameworkElement.Name == name)
                {
                    return frameworkElement;
                }
                T result = FindVisualChild<T>(child, name);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

    }
}
