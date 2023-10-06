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
    public class ProductsViewModel : ObservableObject
    {
        private IAPIService _apiService;
        public ICommand ShowCommand { get; set; }
        public ObservableCollection<Product> Datas { get; set; }
        //public string Element {  get; set; }
        //public Product MyProduct { get; set; }
        public INavigation Navigation { get; set; }

        public ProductsViewModel(INavigation navigation, IAPIService apiService)
        {
            _apiService = apiService;
            Datas = new ObservableCollection<Product>();
            GetAll();
            ShowCommand = new RelayCommand(ShowProduct);
            Navigation = navigation;
        }

        public async void GetAll()
        {
            foreach (Product product in await _apiService.Get())
            {
                Datas.Add(product);
            }
        }

        public async void ShowProduct()
        {
            await Navigation.PushAsync(new ProductDetails());
        }
    }
}
