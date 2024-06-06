using ECommerce.Models;
using ECommerce.ViewModels.Windows;
using System.Windows.Controls;

namespace ECommerce.Views.Views;

/// <summary>
/// Interaction logic for AuthorizationView.xaml
/// </summary>
public partial class AuthorizationView : UserControl
{
    public AuthorizationView()
    {
        InitializeComponent();

        DataContext = new AuthorizationViewModel();
    }
    public AuthorizationView(UserAccount user)
        :base()
    {
        DataContext = new AuthorizationViewModel(user);
    }

    private void Save_Clicked(object sender, System.Windows.RoutedEventArgs e)
    {
        
    }

    private void Cancel_Clicked(object sender, System.Windows.RoutedEventArgs e)
    {

    }
}
