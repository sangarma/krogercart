using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace krogercart.Models
{
    public class Cart
    {
        public int CartID { get; set; }

        [Display(Name = "Cart Creation Date")]
        public string UserID { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Products in Cart")]
        public List<ProductCart> ProductCarts { get; set; } = new List<ProductCart>();
    }
}