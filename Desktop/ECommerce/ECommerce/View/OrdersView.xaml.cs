using ECommerce.Models;
using ECommerce.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

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

			if (!string.IsNullOrEmpty(OrderIdSearchText.Text))
			{
				_orderId = int.Parse(OrderIdSearchText.Text);
			}

			_customer = CustomerNameSearchText.Text ?? "";

			if (StatusCombobox.SelectedItem != null)
			{
				_orderStatus = (OrderStatus)StatusCombobox.SelectedItem;
			}

			Load(_orderId, _customer, _orderStatus);
			OrdersDataGrid.ItemsSource = Orders;
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
			Close();
		}

		private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			var selectedOrder = OrdersDataGrid.SelectedItem as Order;
			
			if (selectedOrder is not null)
			{
				var window = new OrderDetailsView(selectedOrder);
				window.Show();
				//Close();
			}
		}

		private void BtnClose_Click(object sender, RoutedEventArgs e)
		{
			LogOut_Click(sender, e);
		}

		private void Search_Clicked(object sender, RoutedEventArgs e)
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
	}
}
