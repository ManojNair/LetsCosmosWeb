using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LetsCosmosWeb.Data;
using LetsCosmosWeb.Models;

namespace LetsCosmosWeb.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly LetsCosmosWeb.Data.ProductsDbContext _context;

        public CreateModel(LetsCosmosWeb.Data.ProductsDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Product.Id = new Random().Next(1,1000000);

            Product.PartitionKey = Guid.NewGuid().ToString();

            await _context.Product.AddAsync(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
