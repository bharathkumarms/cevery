using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace CEvery.Models
{
    public class Product
    {
        [Key]
        public int SNo { get; set; }
        [Required(ErrorMessage = "The Product Name is required")]
        public string ProductName { get; set; }
    }

    public class ProductDBContext : DbContext
    {
        public ProductDBContext() : base("LeadDBContext") { }
        public DbSet<Product> Products { get; set; }
    }
}