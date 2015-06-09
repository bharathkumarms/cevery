using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEvery.ViewModels;
using CEvery.Models;

namespace CEvery.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private LeadDBContext db = new LeadDBContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<IndicatorStatistics> data = from lead in db.Lead
                                                   group lead by lead.EmployeeName into employeeGroup
                                                   select new IndicatorStatistics()
                                                   {
                                                       EmployeeName = employeeGroup.Key,
                                                       IndicatorCount = employeeGroup.Count()
                                                   };

            IQueryable<IndicatorStatisticsCount> dataCount = from lead in db.Lead
                                                             group lead by lead.Indicator into indicatorGroup
                                                             select new IndicatorStatisticsCount()
                                                   {
                                                       Indicator = indicatorGroup.Key,
                                                       IndicatorCount = indicatorGroup.Count()
                                                   };

            ViewBag.IndicatorCount = dataCount;

            return View(data.ToList());

            //ViewBag.Message = "Your application description page.";
            //return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}