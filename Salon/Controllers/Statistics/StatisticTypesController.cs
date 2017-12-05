﻿using Salon.Models.Statistics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Salon.Controllers.Statistics
{
    public class StatisticTypesController : Controller
    {
        private List<StatisticTypes> definedStatistics = new List<StatisticTypes>();

        public object Streamreader { get; private set; }

        // GET: StatisticTypes
        public ActionResult Index()
        {
            definedStatistics.Add(new StatisticTypes(
                "Besuche pro Monat", "Zeigt die Anzahl der Kundenbesuche pro Monat", "Graph", "/Graph/LineChart?chartName=VisitsMonth"
                ));

            definedStatistics.Add(new StatisticTypes(
                "Visits per TIME", "Shows the visits for a specific time span", "Report", "/"
                ));

            definedStatistics.Add(new StatisticTypes(
                "Customerlist", "Shows all customers", "Report", "/"
                ));

            definedStatistics.Add(new StatisticTypes(
                "Customers last month", "Shows all customers that visited last month", "Report", "/"
                ));

            definedStatistics.Add(new StatisticTypes(
                "Top treatmentes", "Shows the top treatments", "Report", "/"
                ));

            definedStatistics.Add(new StatisticTypes(
                "Percentage visits per gender", "Shows the percentage visits per gender for a specific time span", "Report", "/"
                ));

            return View(definedStatistics);
        }
    }
}