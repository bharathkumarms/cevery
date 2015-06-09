using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web.Mvc;

namespace CEvery.Models
{
    public class Lead
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationNo { get; set; }
        public DateTime CreatedDate { get; set; }
        [DisplayName("Customer")]
        public string CustomerName { get; set; }
        public string Indicator { get; set; }
        [DisplayName("QuotationNo")]
        public int QuotationNumber { get; set; }
        [Required(ErrorMessage = "The Product Name is required")]
        [DisplayName("Product")]
        public string ProductName { get; set; }
        public decimal Value { get; set; }
        public string DocumentPath { get; set; }
        [DisplayName("Employee")]
        public string EmployeeName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Comments { get; set; }

        /*Extra Column added*/
        public DateTime? VisitedDate { get; set; }
        [DisplayName("Department")]
        public string CustomerDepartment { get; set; }
        [DisplayName("Designation")]
        public string CustomerDesignation { get; set; }
        [DisplayName("ContactName")]
        public string CustomerContactName { get; set; }
        [DisplayName("ContactNo")]
        public string CustomerContactNumber { get; set; }
        [DisplayName("ContactEmail")]
        public string CustomerContactEmailId { get; set; }

        [DisplayName("QuoteInfo")]
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string PageContent { get; set; }

        public DateTime? QuoteDate { get; set; }

        public bool IsQuoteStage { get; set; }
    }
    public class LeadDBContext : DbContext
    {
        public DbSet<Lead> Lead { get; set; }

        //public System.Data.Entity.DbSet<CEvery.Models.Product> Products { get; set; }

        //public DbSet<Customer> Customers { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}

    }
}