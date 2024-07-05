using ECommerce.Models;
using System.Windows;
using System.Windows.Input;

namespace ECommerce.View;

public partial class OrdersView : Window
{
    private readonly Employee loggedInEmployee;
	private bool isMaximized = false;

	public OrdersView()
    {
        InitializeComponent();
    }

    public OrdersView(Employee employee):this()
    {
        var win = new OrderDetailsView();
        win.Show();
        loggedInEmployee = employee;
    }

    private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount == 2)
        {
            if (isMaximized)
            {
                WindowState = WindowState.Normal;
                Height = 720;
                Width = 1080;
                isMaximized = false;
            }
            else
            {
                WindowState = WindowState.Maximized;
                isMaximized = true;
            }
        }
    }
}
