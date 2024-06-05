using ECommerce.Models;
using ECommerce.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ViewModels
{
    public class HomePageViewModel:BaseViewModel
    {
        private readonly ProductsService _productsService;
        ObservableCollection<Product> Products { get; }
        ObservableCollection<Category> Categories { get; }
       
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                Search();
            }
            }
        public HomePageViewModel() 
        {
            _productsService = new ProductsService();
            Products = new ObservableCollection<Product>();
            Categories =new ObservableCollection<Category>();
            Load();
        }
        private void Load()
        {
            var products=_productsService.GetProducts();
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }
        private void Search()
        {
            var products=_productsService.GetProducts(_searchText);
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }
    }
}
