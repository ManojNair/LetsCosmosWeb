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
    public class DeleteModel : PageModel
    {
        private readonly LetsCosmosWeb.Data.ProductsDbContext _context;

        public DeleteModel(LetsCosmosWeb.Data.ProductsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id, string partitionKey)
        {
            if (id == null && partitionKey == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FindAsync(id,partitionKey);

            if (Product != null)
            {
                _context.Product.Remove(Product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
