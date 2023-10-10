using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TpMobileStore.Models;
using TpMobileStore.Services;

namespace TpMobileStore.ViewModels
{
    public partial class CartViewModel : BaseViewModel
    {
        private CartService _cartService;
        public ICommand GoBackCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ObservableCollection<ProductCart> ProductCarts { get; set; }
        public decimal Total { get => _cartService.Cart.Total; }
        public CartViewModel(INavigationService navigationService, IAPIService apiService, CartService cartService) : base(navigationService, apiService)
        {
            _cartService = cartService;
            GoBackCommand = new RelayCommand(() => _navigationService.NavigateToAsync("//" + nameof(MainPage)));
            DeleteProductCommand = new RelayCommand<int>(DeleteProduct);
            ProductCarts = new ObservableCollection<ProductCart>(_cartService.Cart.ProductCarts);
            _cartService.CartUpdated += Reload;
        }

        public void Reload()
        {
            ProductCarts = new ObservableCollection<ProductCart>(_cartService.Cart.ProductCarts);

            OnPropertyChanged("ProductCarts");
            OnPropertyChanged("Total");
        }

        private void DeleteProduct(int id)
        {
            _cartService.RemoveProcduct(id);
        }
    }
}
