using ECommerce.Models;
using ECommerce.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ECommerce.View;

public partial class OrdersView : Window
{
    private readonly Employee loggedInEmployee;
    private readonly OrderService _orderService;
    public ObservableCollection<Order> Orders;
    private int? _orderId;
    private string? _customer="";
    private OrderStatus? _orderStatus;
   
    public OrdersView(Employee employee)
    {
        InitializeComponent();  

        string fullName=employee.LastName+" "+employee.FirstName;
        EmpTitle.TextDecorations.Clear();
        EmpTitle.Text = fullName;

        _orderService = new OrderService();
        Orders = new ObservableCollection<Order>();
        
        if (!string.IsNullOrEmpty(OrderIdSearchText.Text))
            _orderId = int.Parse(OrderIdSearchText.Text);
        else _orderId = null;
        _customer = CustomerNameSearchText.Text??"";
        if(StatusCombobox.SelectedItem != null )
            _orderStatus=(OrderStatus)StatusCombobox.SelectedItem;
        else _orderStatus = null;
        
        Load(_orderId,_customer,_orderStatus);
        OrdersDataGrid.ItemsSource = Orders;

    }
    
    void Load(int? OrderId ,string Customer, OrderStatus? Status)
    {
        var orders = _orderService.GetOrder(OrderId,Customer,Status);
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
        var selectedOrder=OrdersDataGrid.SelectedItem as Order;
        if (selectedOrder is not null)
        {
            var window = new OrderDetailsView(selectedOrder);
            window.Show();
            this.Close();
        }
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {

    }
}
