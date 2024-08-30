using ECommerce.Models;
using ECommerce.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ECommerce.View
{
    /// <summary>
    /// Interaction logic for OrderDetailsView.xaml
    /// </summary>

    public partial class OrderDetailsView : Window
    {
        private readonly OrderDetailService _orderDetailService;
        public List<OrderDetail> _orderDetails;
        public event PropertyChangedEventHandler? PropertyChanged;
        public List<Product> _products;

        public OrderDetailsView(Order order,ObservableCollection<Order> orders)
        {
            InitializeComponent();

            _orderDetailService = new();
            _orderDetails = _orderDetailService.GetOrderDetails(order.Id);

            _products = RefreshData(_orderDetails);

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

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int id=int.Parse(IdInput.Text);
            var order=_orderDetails.FirstOrDefault(x => x.Product.Id == id);
            order.Status = OrderStatus.Sold;
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void ProductCancel_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = Products.SelectedItem as Product;


            if (selectedItem != null)
            {
                var item = _orderDetails.FirstOrDefault(x => x.Product.Id == selectedItem.Id);

                if (item != null)
                {
                    _orderDetails.Remove(item);
                }
            }

            var button = sender as Button;
            var dataGridRow = button.Tag as DataGridRow;

            if (dataGridRow != null)
            {
                var button1 = FindVisualChild<Button>(dataGridRow, "CancelButton");
                var button2 = FindVisualChild<Button>(dataGridRow, "RefundButton");

                if (button1 != null)
                {
                    var product = _products.FirstOrDefault(x => x.Id == selectedItem.Id);

                    button1.Visibility = Visibility.Collapsed;
                }

                if (button2 != null)
                {
                    button2.Visibility = Visibility.Collapsed;
                }

                Products.ItemsSource = null;
                Products.ItemsSource = RefreshData(_orderDetails);
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
