using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public Guid Barcode { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
