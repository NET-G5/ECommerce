using ECommerce.Models;
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

        Employee? loggedInEmployee = CheckAdmin(username, password);

        if (loggedInEmployee is null)
        {
            return;
        }

        var ordersView = new OrdersView(loggedInEmployee);
        ordersView.Show();

        this.Close();
    }

    private Employee? CheckAdmin(string username, string password)
    {
        List<Employee> employees =
        [
            new Employee()
            {
                Id = 1,
                UserName = "b",
                Password = "b",
                FirstName = "Bobur",
                LastName = "Boboyev"
            },
            new Employee()
            {
                Id = 1,
                UserName = "bobur",
                Password = "boboyev2004",
                FirstName = "Bobur",
                LastName = "Boboyev"
            },
            new Employee()
            {
                Id = 1,
                UserName = "jamshidbek",
                Password = "choriyev0405",
                FirstName = "Jamshidbek",
                LastName = "Choriyev"
            },
            new Employee()
            {
                Id = 1,
                UserName = "1",
                Password = "1",
                FirstName = "Ramazon",
                LastName = "Choriyev"
            },
            new Employee()
            {
                Id = 1,
                UserName = "akhmadovich",
                Password = "akhmadovich0302",
                FirstName = "Ro'zimuhammad",
                LastName = "Abdullayev"
            },
        ];

        foreach (var employee in employees)
        {
            if (username == employee.UserName && password == employee.Password)
            {
                return employee;
            }
        }

        MessageBox.Show("Username or password is incorrect. Please, try again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return null;
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
        var result = MessageBox.Show("Are you sure you want to exit the program?", "Ecommerce", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (result == MessageBoxResult.Yes)
        {
            Environment.Exit(0);
        }
    }

}