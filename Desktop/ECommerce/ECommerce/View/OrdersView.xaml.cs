using ECommerce.Models;
using ECommerce.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ECommerce.View;

public partial class OrdersView : Window
{
    private readonly Employee loggedInEmployee;
    private readonly OrderService _orderService;
     ObservableCollection<Order> _orders;
    public OrdersView()
    {
        InitializeComponent();  
        _orderService = new OrderService();
        _orders = new ObservableCollection<Order>();
    }

    public OrdersView(Employee employee)
    {
        loggedInEmployee = employee;
    }
    void Load()
    {

    }


    private void BtnMinimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void BtnClose_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void LogOut_Click(object sender, RoutedEventArgs e)
    {

    }
}
