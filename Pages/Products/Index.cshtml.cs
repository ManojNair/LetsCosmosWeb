using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LetsCosmosWeb.Data;
using LetsCosmosWeb.Models;

namespace LetsCosmosWeb.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ProductsDbContext _context;

        public IndexModel(ProductsDbContext context)
        {
            _context = context;
        }

        public List<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            Product =_context.Product.ToList();
        }
    }
}
