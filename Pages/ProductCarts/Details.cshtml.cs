using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using krogercart.Models;

namespace krogercart.Pages_ProductCarts
{
    public class DetailsModel : PageModel
    {
        private readonly krogercart.Models.AppDbContext _context;

        public DetailsModel(krogercart.Models.AppDbContext context)
        {
            _context = context;
        }

        public ProductCart ProductCart { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productcart = await _context.ProductCarts.FirstOrDefaultAsync(m => m.CartID == id);

            if (productcart is not null)
            {
                ProductCart = productcart;

                return Page();
            }

            return NotFound();
        }
    }
}
