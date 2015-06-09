using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CEvery.Models;
using PagedList;
using System.Globalization;
using Microsoft.AspNet.Identity;

namespace CEvery.Controllers
{
    [Authorize]
    public class LeadsController : Controller
    {
        private LeadDBContext db = new LeadDBContext();

        // GET: /Leads/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, string searchFromString, string searchToString, int? page, string indicatorSearch)
        {
            string myUserName = User.Identity.GetUserName();
            string userFilter = "";
            if (myUserName.Equals("ramesh")){
                userFilter = "";
            }
            else
            {
                userFilter = myUserName;
            }


            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var leads = from l in db.Lead
                        select l;

            if (!String.IsNullOrEmpty(userFilter) && !myUserName.Equals("venkatraman"))
            {
                leads = leads.Where(l => l.EmployeeName.ToUpper().Contains(userFilter.ToUpper()));
            }

            if (myUserName.Equals("venkatraman"))
            {
                leads = leads.Where(l => l.IsQuoteStage == true);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                leads = leads.Where(l => l.CustomerName.ToUpper().Contains(searchString.ToUpper()));
                                       //|| l.FirstMidName.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!String.IsNullOrEmpty(searchFromString) && !String.IsNullOrEmpty(searchToString))
            {
                DateTime fromDate = DateTime.ParseExact(searchFromString, "dd MMM yyyy", CultureInfo.InvariantCulture);
                DateTime toDate = DateTime.ParseExact(searchToString, "dd MMM yyyy", CultureInfo.InvariantCulture);
                leads = leads.Where(l => l.ModifiedDate >= fromDate && l.ModifiedDate <= toDate);
            }

            if (!String.IsNullOrEmpty(indicatorSearch))
            {
                leads = leads.Where(l => l.Indicator.ToUpper().Contains(indicatorSearch.ToUpper()));
                //|| l.FirstMidName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    leads = leads.OrderByDescending(l => l.EmployeeName);
                    break;
                case "Date":
                    leads = leads.OrderBy(l => l.ModifiedDate);
                    break;
                case "date_desc":
                    leads = leads.OrderByDescending(l => l.ModifiedDate);
                    break;
                default:
                    leads = leads.OrderByDescending(l => l.ModifiedDate);
                    break;
            }


            int pageSize = 150;
            int pageNumber = (page ?? 1);
            return View(leads.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Leads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lead lead = db.Lead.Find(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            return View(lead);
        }

        // GET: /Leads/Create
        public ActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            //
            SelectListItem s = new SelectListItem();
            s.Text = "Red";
            s.Value = "Red";
            items.Add(s);
            SelectListItem s1 = new SelectListItem();
            s1.Text = "Green";
            s1.Value = "Green";
            items.Add(s1);
            SelectListItem s2 = new SelectListItem();
            s2.Text = "Yellow";
            s2.Value = "Yellow";
            items.Add(s2);
            //
            ViewBag.IndicatorList = items;

            List<SelectListItem> finalCust = new List<SelectListItem>();
            //
            CustomerDBContext db1 = new CustomerDBContext();
            var customerList = db1.Customers;
            foreach (var c in customerList)
            {
                SelectListItem cust = new SelectListItem();
                cust.Text = c.CustomerName;
                cust.Value = c.CustomerName;
                finalCust.Add(cust);
            }
            ViewBag.CustomerList = finalCust;



            List<SelectListItem> finalProduct = new List<SelectListItem>();
            //
            ProductDBContext db2 = new ProductDBContext();
            var productList = db2.Products;
            foreach (var p in productList)
            {
                SelectListItem prod = new SelectListItem();
                prod.Text = p.ProductName;
                prod.Value = p.ProductName;
                finalProduct.Add(prod);
            }
            ViewBag.ProductList = finalProduct;

            return View();
        }

        // POST: /Leads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicationNo,CreatedDate,CustomerName,Indicator,QuotationNumber,ProductName,Value,DocumentPath,EmployeeName,ModifiedDate,Comments, VisitedDate, CustomerDepartment, CustomerDesignation, CustomerContactName, CustomerContactNumber, CustomerContactEmailId, PageContent, QuoteDate, IsQuoteStage")] Lead lead)
        {
            if (ModelState.IsValid)
            {
                db.Lead.Add(lead);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lead);
        }

        // GET: /Leads/Edit/5
        public ActionResult Edit(int? id)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            //
            SelectListItem s = new SelectListItem();
            s.Text = "Red";
            s.Value = "Red";
            items.Add(s);
            SelectListItem s1 = new SelectListItem();
            s1.Text = "Green";
            s1.Value = "Green";
            items.Add(s1);
            SelectListItem s2 = new SelectListItem();
            s2.Text = "Yellow";
            s2.Value = "Yellow";
            items.Add(s2);
            //
            ViewBag.IndicatorList = items;

            List<SelectListItem> finalCust = new List<SelectListItem>();
            //
            CustomerDBContext db1 = new CustomerDBContext();
            var customerList = db1.Customers;
            foreach (var c in customerList)
            {
                SelectListItem cust = new SelectListItem();
                cust.Text = c.CustomerName;
                cust.Value = c.CustomerName;
                finalCust.Add(cust);
            }
            ViewBag.CustomerList = finalCust;

            List<SelectListItem> finalProduct = new List<SelectListItem>();
            //
            ProductDBContext db2 = new ProductDBContext();
            var productList = db2.Products;
            foreach (var p in productList)
            {
                SelectListItem prod = new SelectListItem();
                prod.Text = p.ProductName;
                prod.Value = p.ProductName;
                finalProduct.Add(prod);
            }
            ViewBag.ProductList = finalProduct;



            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lead lead = db.Lead.Find(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            return View(lead);
        }

        // POST: /Leads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicationNo,CreatedDate,CustomerName,Indicator,QuotationNumber,ProductName,Value,DocumentPath,EmployeeName,ModifiedDate,Comments, VisitedDate, CustomerDepartment, CustomerDesignation, CustomerContactName, CustomerContactNumber, CustomerContactEmailId, PageContent, QuoteDate, IsQuoteStage")] Lead lead)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lead).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lead);
        }

        // GET: /Leads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lead lead = db.Lead.Find(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            return View(lead);
        }

        // POST: /Leads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lead lead = db.Lead.Find(id);
            db.Lead.Remove(lead);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
