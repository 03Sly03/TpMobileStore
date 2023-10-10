using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMobileStore.Models
{
    public class ProductCart
    {
        private Product _product;
        private int _quantity;

        public Product Product { get => _product; set => _product = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
    }
}
