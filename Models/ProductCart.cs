using System.ComponentModel.DataAnnotations;

namespace krogercart.Models
{
    public class ProductCart
    {
        public int ProductCartID { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; } = default!;

        public int CartID { get; set; }
        public Cart Cart { get; set; } = default!;

        public int Quantity { get; set; }
    }
}