using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace CEvery.Models
{
    public class Customer
    {
        [Key]
        public int SNo { get; set; }
        [Required(ErrorMessage = "The Customer Name is required")]
        public string CustomerName { get; set; }
    }

    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext() : base("LeadDBContext") { }
        public DbSet<Customer> Customers { get; set; }
    }
}