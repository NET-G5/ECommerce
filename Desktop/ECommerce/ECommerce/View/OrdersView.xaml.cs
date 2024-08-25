using ECommerce.Models;
using ECommerce.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ECommerce.View
{
    public partial class OrdersView : Window
    {
        private readonly Employee loggedInEmployee;
        private readonly OrderService _orderService;
        public List<OrderStatus> OrderStatuses { get; } =
            [
                OrderStatus.Refunded,
                OrderStatus.Pending,
                OrderStatus.Canceled,
                OrderStatus.Sold
            ];

        public ObservableCollection<Order> Orders { get; }

        private int? _orderId = null;
        private string? _customer = null;
        private OrderStatus? _orderStatus = null;

        public OrdersView(Employee employee)
        {
            InitializeComponent();

            DataContext = this;

            string fullName = employee.ToString();
            EmpTitle.TextDecorations.Clear();
            EmpTitle.Text = fullName;

            _orderService = new OrderService();
            Orders = new ObservableCollection<Order>();

            OrderIdSearchText.KeyDown += ((sender, e) =>
                            {
                                if (e.Key == Key.Enter)
                                {
                                    Search_Clicked(sender, e);
                                }
                            });
            CustomerNameSearchText.KeyDown += ((sender, e) =>
                                {
                                    if (e.Key == Key.Enter)
                                    {
                                        Search_Clicked(sender, e);
                                    }
                                });
            StatusCombobox.KeyDown += ((sender, e) =>
                                    {
                                        if (e.Key == Key.Enter)
                                        {
                                            Search_Clicked(sender, e);
                                        }
                                    });
            RefreshingDataGrid();
        }

        void Load(int? OrderId, string Customer, OrderStatus? Status)
        {
            var orders = _orderService.GetOrder(OrderId, Customer, Status);

            Orders.Clear();
            foreach (var order in orders)
            {
                Orders.Add(order);
            }
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void DataGridRow_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            var selectedOrder = OrdersGrid.SelectedItem as Order;

            if (selectedOrder is not null)
            {
                var window = new OrderDetailsView(selectedOrder);
                window.Show();
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Search_Clicked(object sender, RoutedEventArgs e)
        {
            RefreshingDataGrid();
        }

        private void RefreshingDataGrid()
        {
            try
            {
                if (!string.IsNullOrEmpty(OrderIdSearchText.Text))
                {
                    _orderId = int.Parse(OrderIdSearchText.Text);
                }
                else
                {
                    _orderId = null;
                }

                _customer = CustomerNameSearchText.Text;

                if (StatusCombobox.SelectedItem != null)
                {
                    _orderStatus = (OrderStatus)StatusCombobox.SelectedItem;
                }
                else
                {
                    _orderStatus = null;
                }

                Load(_orderId, _customer, _orderStatus);
                OrdersGrid.ItemsSource = Orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error!\nDetails: {ex.Message}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    row.DetailsVisibility =
                    row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                    break;
                }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button Clicked","success", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Details_Button(object sender, RoutedEventArgs e)
        {
            var selectedOrder = OrdersGrid.SelectedItem as Order;

            if (selectedOrder is not null)
            {
                var window = new OrderDetailsView(selectedOrder);
                window.Show();
            }
        }
    }
}
