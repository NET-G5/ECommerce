using ECommerce.Models;
using ECommerce.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using MessageBox = System.Windows.MessageBox;

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

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit the program?", "Ecommerce", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }

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
                MessageBox.Show($"Error!\nDetails: {ex.Message}","Ecommerce",MessageBoxButton.OK,MessageBoxImage.Error);
            }
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
