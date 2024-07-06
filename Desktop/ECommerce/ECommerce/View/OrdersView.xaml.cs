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

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedOrder = OrdersDataGrid.SelectedItem as Order;

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
                OrdersDataGrid.ItemsSource = Orders;
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
        private void image1_Loaded(object sender, RoutedEventArgs e)
        {
            // replace it with what ever you like
            // for example image1.Source = GetBitmapFromFile("myImage.img");
            image1.Source = GetBitmapFromFile("Images\\ProfilePhoto.jpg");
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            // first we take the coordinates of the mouse relative to the top left corner of our window
            var pos = e.GetPosition(this);
            // then we set the margin of the image control so that its top left corner is at the position
            image1.Margin = new Thickness(pos.X, pos.Y, 0, 0);
        }

        private System.Windows.Media.Imaging.BitmapImage GetBitmapFromFile(string path)
        {
            System.Windows.Media.Imaging.BitmapImage img = new System.Windows.Media.Imaging.BitmapImage();
            img.BeginInit();
            // Every path can be represented by an URI
            img.UriSource = new System.Uri(path, System.UriKind.RelativeOrAbsolute);
            img.EndInit();

            return img;
        }

        private System.Windows.Media.Imaging.BitmapImage GetBitmapFromGDI(System.Drawing.Bitmap bmp)
        {
            var strm = new System.IO.MemoryStream();
            // We temporary save the bitmap to a stream inside the memory
            bmp.Save(strm, System.Drawing.Imaging.ImageFormat.Bmp);
            strm.Position = 0;
            System.Windows.Media.Imaging.BitmapImage img = new System.Windows.Media.Imaging.BitmapImage();
            img.BeginInit();
            // The BitmapImage should be loaded from the stream inside memory
            img.StreamSource = strm;
            img.EndInit();
            strm.Dispose();

            return img;
        }
    }
}
