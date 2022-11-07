using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services.Models
{
    public class Cart
    {
        public Dictionary<string, CartItem> Items { get; set; } = new Dictionary<string, CartItem>();
    }

    public class CartItem
    {
        public Product CartProduct { get; set; }
        public int Quantity { get; set; }
    }
}
