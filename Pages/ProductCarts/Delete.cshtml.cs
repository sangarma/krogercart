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

        public async Task<IActionResult> OnGetAsync(int? cartId, int? productId)
        {
            if (cartId == null || productId == null)
            {
                return NotFound();
            }

            ProductCart = await _context.ProductCarts
                .Include(pc => pc.Product)
                .Include(pc => pc.Cart)
                .FirstOrDefaultAsync(pc => pc.CartID == cartId && pc.ProductID == productId);

            if (ProductCart == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? cartId, int? productId)
        {
            if (cartId == null || productId == null)
            {
                return NotFound();
            }

            ProductCart = await _context.ProductCarts
                .FirstOrDefaultAsync(pc => pc.CartID == cartId && pc.ProductID == productId);

            if (ProductCart != null)
            {
                _context.ProductCarts.Remove(ProductCart);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}