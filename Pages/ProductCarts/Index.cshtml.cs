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
    public class IndexModel : PageModel
    {
        private readonly krogercart.Models.AppDbContext _context;

        public IndexModel(krogercart.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<ProductCart> ProductCart { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ProductCart = await _context.ProductCarts
                .Include(p => p.Cart)
                .Include(p => p.Product).ToListAsync();
        }
    }
}
