using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TpMobileStore.Models;
using TpMobileStore.Pages;
using TpMobileStore.Services;

namespace TpMobileStore.ViewModels
{
    public partial class ProductsViewModel : BaseViewModel
    {

        public ICommand ShowCommand { get; set; }
        public ObservableCollection<Product> Datas { get; set; }


        public ProductsViewModel(INavigationService navigationService, IAPIService apiService) : base(navigationService, apiService)
        {

            Datas = new ObservableCollection<Product>();
            GetAll();

            ShowCommand = new Command<Product>(execute: ShowProduct);

        }

        public async void GetAll()
        {
            foreach (Product product in await _apiService.Get())
            {
                Datas.Add(product);
            }
        }
        
        public async void ShowProduct(Product product)
        {
            await _navigationService.NavigateToAsync(nameof(ProductDetails), new Dictionary<string, object>() { { "MyProductDetails", product } });
        }
    }
}
