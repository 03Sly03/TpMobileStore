using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMobileStore.Models
{
    public class Cart
    {
        public decimal Total
        {
            get
            {
                decimal total = 0;
                ProductCarts.ForEach(product =>
                {
                    total += product.Quantity * product.Product.Price;
                });
                return total;
            }
        }
        
        public List<ProductCart> ProductCarts { get; set; }

        public Cart()
        {
            ProductCarts = new List<ProductCart>();
        }
    }
}
