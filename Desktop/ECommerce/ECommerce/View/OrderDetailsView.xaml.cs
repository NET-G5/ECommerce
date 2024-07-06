using ECommerce.Models;
using ECommerce.Services;
using System.Windows;

namespace ECommerce.View;

public partial class OrderDetailsView
{
	private readonly OrderDetailService _orderDatailService;
	private readonly OrderService _orderService;
	private List<OrderDetail> _orderDetails;

	public OrderDetailsView(Order order)
	{
		InitializeComponent();

		_orderDatailService = new();
		_orderService = new();
		_orderDetails = _orderDatailService.GetOrderDetails(order.Id);

		Id.Text = order.Id.ToString();
		FullName.Text = order.Customer.ToString();
		OrderDate.Text = order.OrderedDate.ToString("dd/MM/yyyy hh:mm:ss HH");
		ExpireDate.Text = order.ExpireDate.ToString("dd/MM/yyyy hh:mm:ss HH");
		TotalPrice.Text = CountingTotalPrice().ToString() + " so'm";
	}

	private double CountingTotalPrice()
	{
		double result = 0;

		foreach (var item in _orderDetails)
		{
			result += item.TotalPrice;
		}

		return result;
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
