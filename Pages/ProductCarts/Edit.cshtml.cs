using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public async Task<IActionResult> OnGetAsync(int? cartId, int? productId)
        {
            if (cartId == null || productId == null)
            {
                return NotFound();
            }

            
            ProductCart = await _context.ProductCarts
                .Include(pc => pc.Product)
                .FirstOrDefaultAsync(m => m.CartID == cartId && m.ProductID == productId);

            if (ProductCart == null)
            {
                return NotFound();
            }

            return Page();
        }

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
                if (!ProductCartExists(ProductCart.CartID, ProductCart.ProductID))
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

        private bool ProductCartExists(int cartId, int productId)
        {
            return _context.ProductCarts.Any(e => e.CartID == cartId && e.ProductID == productId);
        }
    }
}