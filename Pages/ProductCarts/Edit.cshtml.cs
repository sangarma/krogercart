using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using krogercart.Models;

namespace krogercart.Pages_ProductCarts
{
    public class EditModel : PageModel
    {
        private readonly krogercart.Models.AppDbContext _context;

        public EditModel(krogercart.Models.AppDbContext context)
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

            var productcart =  await _context.ProductCarts.FirstOrDefaultAsync(m => m.CartID == id);
            if (productcart == null)
            {
                return NotFound();
            }
            ProductCart = productcart;
           ViewData["CartID"] = new SelectList(_context.Carts, "CartID", "CartID");
           ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProductCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCartExists(ProductCart.CartID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductCartExists(int id)
        {
            return _context.ProductCarts.Any(e => e.CartID == id);
        }
    }
}
