using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LetsCosmosWeb.Models;

namespace LetsCosmosWeb.Data
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext (DbContextOptions<ProductsDbContext> options)
            : base(options)
        {
        }

        public DbSet<LetsCosmosWeb.Models.Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasPartitionKey(p => p.PartitionKey);
            modelBuilder.Entity<Product>().ToContainer("Products");
        }
    }
}
