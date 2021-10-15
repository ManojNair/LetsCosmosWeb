using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetsCosmosWeb.Models
{
    public class Product
    {
 
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double  Cost { get; set; }

        public string PartitionKey { get; set; }
    }
}
