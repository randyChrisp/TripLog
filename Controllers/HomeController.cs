using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Controllers
{
    public class HomeController : Controller
    {
        private TripContext context { get; set; }

        public HomeController(TripContext ctx)
        {
            context = ctx;
        }

        public ViewResult Index()
        {
            List<TripsLog> trips = context.Trips
                .OrderBy(s => s.StartDate)
                .ToList();
            return View(trips);
        }
    }
}
