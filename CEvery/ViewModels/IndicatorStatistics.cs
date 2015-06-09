using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CEvery.ViewModels
{
    public class IndicatorStatistics
    {
        public string EmployeeName { get; set; }
        public int IndicatorCount { get; set; }
    }

    public class IndicatorStatisticsCount
    {
        public string Indicator { get; set; }
        public int IndicatorCount { get; set; }
    }
}