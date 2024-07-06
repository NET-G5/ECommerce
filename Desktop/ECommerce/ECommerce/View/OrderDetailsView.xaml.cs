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
		private List<Product> _products;
        private List<OrderDetail> _orderDetails;

		public OrderDetailsView(Order order)
        {
            InitializeComponent();
            
            _orderDatailService = new();
            _products = [];
            _orderDetails = _orderDatailService.GetOrderDetails(order.Id);

            RefreshData(order);

            Products.ItemsSource = _products;
		}

        private double TakingTotalPrice()
        {
            double totalPrice = 0;

			foreach (var detail in _orderDetails)
			{
                for (int i = 0; i < detail.Amount; i++)
                {
                    _products.Add(detail.Product);
				    totalPrice += detail.Product.Price;
                }
			}

            return totalPrice;
		}
       
        private void RefreshData(Order order)
        {
			Id.Text = order.Id.ToString();
			FullName.Text = order.Customer.ToString();
			ExpireDate.Text = order.ExpireDate.ToString("dd/MM/yyyy HH:mm");
			OrderDate.Text = order.OrderedDate.ToString("dd/MM/yyyy HH:mm");
			TotalPrice.Text = TakingTotalPrice().ToString() + " so'm";
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
