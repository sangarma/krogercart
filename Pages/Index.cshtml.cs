using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using krogercart.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace krogercart.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(AppDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Product> Products { get; set; } = new List<Product>();

        [BindProperty]
        public int ProductID { get; set; }

        public void OnGet()
        {
            Products = _context.Products.ToList();
        }

        public IActionResult OnPostAddToCart()
        {
            string userId = "User123"; 

            // Find or create the cart for this user
            var cart = _context.Carts
                .Include(c => c.ProductCarts)
                .FirstOrDefault(c => c.UserID == userId);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserID = userId,
                    CreationDate = System.DateTime.UtcNow
                };

                _context.Carts.Add(cart);
                _context.SaveChanges();
            }

            // check if the product is in cart
            var productCart = cart.ProductCarts.FirstOrDefault(pc => pc.ProductID == ProductID);
            if (productCart != null)
            {
                
                productCart.Quantity += 1;
            }
            else
            {
                
                productCart = new ProductCart
                {
                    CartID = cart.CartID,
                    ProductID = ProductID,
                    Quantity = 1
                };
                _context.ProductCarts.Add(productCart);
            }

            _context.SaveChanges();

            
            return RedirectToPage();
        }
    }
}