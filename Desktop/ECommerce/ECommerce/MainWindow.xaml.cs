using ECommerce.View;
using System.Windows;
using System.Windows.Input;

namespace ECommerce;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnLogin_Clicked(object sender, RoutedEventArgs e)
    {
        string username = UsernameInput.Text;
        string password = PasswordInput.Password.ToString();
        if (!CheckAdmin(username, password))
        {
            return;
        }
        
        var ordersView = new OrdersView();
        ordersView.Show();

        this.Close();
    }

    private bool CheckAdmin(string username, string password)
    {
        if (username == "pdp" && password == "pdp123")
        {
            return true;
        }

        MessageBox.Show("Username or password is incorrect. Please, try again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return false;
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }

    private void BtnMinimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void BtnClose_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {

    }
}