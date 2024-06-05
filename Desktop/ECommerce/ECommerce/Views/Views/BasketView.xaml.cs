using ECommerce.Models;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ECommerce.Views.Views;

/// <summary>
/// Interaction logic for BasketView.xaml
/// </summary>
public partial class BasketView : UserControl
{
    public ObservableCollection<Product> Products { get; set; }
    public BasketView()
    {
        InitializeComponent();


        Products = new ObservableCollection<Product>
        {
            new Product { Name = "Carolina Herrera Good Girl", Description = "Eau de parfum", Price = 156, ImageUrl = @"C:\Users\Пользователь\OneDrive\Rasmlar\Ekran rasmlari\Screenshot 2024-06-05 232204.png" },
            new Product { Name = "Creed Aventus", Description = "Eau de parfum", Price = 152, ImageUrl = @"C:\Users\Пользователь\OneDrive\Rasmlar\Ekran rasmlari\Screenshot 2024-06-05 232204.png"}
        };

        OrderDataGrid.ItemsSource = Products;
    }

}
