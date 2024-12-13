using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using krogercart.Models;

namespace krogercart.Pages_ProductCarts
{
    public class CreateModel : PageModel
    {
        private readonly krogercart.Models.AppDbContext _context;

        public CreateModel(krogercart.Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CartID"] = new SelectList(_context.Carts, "CartID", "CartID");
        ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID");
            return Page();
        }

        [BindProperty]
        public ProductCart ProductCart { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProductCarts.Add(ProductCart);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
