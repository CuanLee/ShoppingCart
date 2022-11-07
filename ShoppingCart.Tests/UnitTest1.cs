using ShoppingCart.Services.Models;
using ShoppingCart.Services.Services;

namespace ShoppingCart.Tests
{
    public class UnitTest1
    {
        private AddProductService _productService;
        public UnitTest1()
        {
            _productService = new AddProductService(new Cart());
        }

        [Fact]
        public void Test1()
        {
            var product = new Product
            {
                Name = "Test Name",
                Barcode = Guid.NewGuid(),
                Category = "Fruit",
                UnitPrice = 10
            };

            _productService.AddProduct(product);

            var record = _productService.GetProduct(product.Barcode);
            Assert.NotNull(record);
        }

        [Fact]
        public void ShouldValidateCartItemAddedSuccessfullyWithQuantity()
        {
            var product = new Product
            {
                Name = "Test Name",
                Barcode = Guid.NewGuid(),
                Category = "Fruit",
                UnitPrice = 10
            };

            var quantity = 5;

            _productService.AddProduct(product, quantity);

            var record = _productService.GetProduct(product.Barcode);
            Assert.NotNull(record);
            Assert.Equal(record.Quantity, quantity);
        }

        [Fact]
        public void ShouldValidateCartItemQuantitySuccessfullyUpdated()
        {
            var product = new Product
            {
                Name = "Test Name",
                Barcode = Guid.NewGuid(),
                Category = "Fruit",
                UnitPrice = 10
            };

            var quantity = 5;

            _productService.AddProduct(product, quantity);
            var record = _productService.GetProduct(product.Barcode);
            Assert.NotNull(record);
            Assert.Equal(record.Quantity, quantity);

            var updatedQuantity = 500;
            var updateCartItem = _productService.UpdateCartItem(product.Barcode, updatedQuantity);

            Assert.Equal(updateCartItem.Quantity, updatedQuantity);
        }
    }
}