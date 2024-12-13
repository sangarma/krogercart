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
    public class DeleteModel : PageModel
    {
        private readonly krogercart.Models.AppDbContext _context;

        public DeleteModel(krogercart.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productcart = await _context.ProductCarts.FindAsync(id);
            if (productcart != null)
            {
                ProductCart = productcart;
                _context.ProductCarts.Remove(ProductCart);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
