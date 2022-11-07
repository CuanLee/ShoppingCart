using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Services.Models;

namespace ShoppingCart.Services.Services
{
    public class AddProductService
    {
        private Cart _cart;
        public AddProductService(Cart cart)
        {
            _cart = cart;
        }

        public void AddProduct(Product product)
        {
            var cartItem = new CartItem
            {
                CartProduct = product,
            };
            _cart.Items.Add(product.Barcode.ToString(), cartItem);
        }

        public void AddProduct(Product product, int quantity)
        {
            var cartItem = new CartItem
            {
                CartProduct = product,
                Quantity = quantity };

            _cart.Items.Add(product.Barcode.ToString(), cartItem);
        }

        public CartItem GetProduct(Guid barCode)
        {
            if(_cart.Items.ContainsKey($"{barCode}"))
            {
                return _cart.Items[$"{barCode}"];
            }

            return null;
        }

        public CartItem UpdateCartItem(Guid barCode, int quantity)
        {
            if (_cart.Items.ContainsKey($"{barCode}"))
            {
                _cart.Items[$"{barCode}"].Quantity = quantity;
                return _cart.Items[$"{barCode}"];
            }

            return null;
        }
    }
}
