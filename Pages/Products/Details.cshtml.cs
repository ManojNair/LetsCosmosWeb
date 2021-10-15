using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LetsCosmosWeb.Data;
using LetsCosmosWeb.Models;

namespace LetsCosmosWeb.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly LetsCosmosWeb.Data.ProductsDbContext _context;

        public DetailsModel(LetsCosmosWeb.Data.ProductsDbContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
