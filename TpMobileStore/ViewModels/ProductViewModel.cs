using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TpMobileStore.Models;
using TpMobileStore.Pages;
using TpMobileStore.Services;

namespace TpMobileStore.ViewModels
{
    public partial class ProductViewModel : BaseViewModel
    {
        private CartService _cartService;
        private Product _myProductDetails;
        private ArgsService _argsService;
        public ICommand GoBackCommand { get; set; }
        public ICommand AddToCartCommand { get; set; }
        public Product MyProductDetails
        {
            get => _myProductDetails;
            set
            {
                _myProductDetails = value;
                OnPropertyChanged("Title");
                OnPropertyChanged("Price");
                OnPropertyChanged("Description");
                OnPropertyChanged("Category");
                OnPropertyChanged("Image");
            }
        }

        public string Title { get => MyProductDetails != null ? MyProductDetails.Title : null; }
        public decimal Price { get => MyProductDetails != null ? MyProductDetails.Price : 0; }
        public string Description { get => MyProductDetails != null ? MyProductDetails.Description : null; }
        public string Category { get => MyProductDetails != null ? MyProductDetails.Category : null; }
        public string Image { get => MyProductDetails != null ? MyProductDetails.Image : null; }


        public ProductViewModel(INavigationService navigationService, IAPIService apiService, ArgsService argsService, CartService cartService) : base(navigationService, apiService)
        {
            _argsService = argsService;
            GoBackCommand = new RelayCommand(() => _navigationService.NavigateToAsync("//" + nameof(MainPage)));
            _argsService.ArgsUpdated += LoadData;
            _cartService = cartService;
            AddToCartCommand = new RelayCommand(() =>
            {
                _cartService.AddProduct(MyProductDetails.Id);
                _navigationService.NavigateToAsync("//" + nameof(CartPage));
            });
            LoadData();
        }
        private void LoadData()
        {
            MyProductDetails = (Product)_argsService.Get("MyProduct");
        }
    }
}
