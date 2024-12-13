using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace krogercart.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string ImageURL { get; set; } = string.Empty;

        // Navigation property for the relationship between Product and ProductCart
        public List<ProductCart>? ProductCarts { get; set; } = default!;
    }
}