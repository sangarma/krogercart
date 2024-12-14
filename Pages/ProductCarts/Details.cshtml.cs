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

        public async Task<IActionResult> OnGetAsync(int? cartId, int? productId)
        {
            if (cartId == null || productId == null)
            {
                return NotFound();
            }

            ProductCart = await _context.ProductCarts
                .Include(pc => pc.Product)
                .FirstOrDefaultAsync(pc => pc.CartID == cartId && pc.ProductID == productId)!;

            if (ProductCart == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}