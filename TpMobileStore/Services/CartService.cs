using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpMobileStore.Models;

namespace TpMobileStore.Services
{
    public class CartService
    {
        private Cart _cart;
        public Cart Cart { get => _cart; }

        public event Action CartUpdated;

        private IAPIService _apiService;

        public CartService(IAPIService apiService)
        {
            _apiService = apiService;
            _cart = new Cart();
        }

        public async void AddProduct(int id)
        {
            bool result = false;
            ProductCart productCart = Cart.ProductCarts.FirstOrDefault(product => product.Product.Id == id);
            if (productCart != null)
            {
                productCart.Quantity++;
                result = true;
            }
            else
            {
                Product product = await _apiService.GetById(id);
                if (product != null)
                {
                    _cart.ProductCarts.Add(new ProductCart() { Product = product, Quantity = 1 });
                    result = true;
                }
            }
            if (result && CartUpdated != null)
            {
                CartUpdated();
            }
        }

        public void RemoveProcduct(int id)
        {
            bool result = false;
            ProductCart productCart = Cart.ProductCarts.FirstOrDefault(product => product.Product.Id == id);
            if (productCart != null)
            {
                if (productCart.Quantity > 1)
                {
                    productCart.Quantity--;
                }
                else
                {
                    _cart.ProductCarts.Remove(productCart);
                }
                result = true;
            }
            if(result && CartUpdated != null)
            {
                CartUpdated();
            }
        }
    }



}
