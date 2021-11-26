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
        private Repository<TripsLog> data { get; set; }

        public HomeController(TripContext ctx)
        {
            data = new Repository<TripsLog>(ctx);
        }

        public ViewResult Index()
        {
            var options = new QueryOptions<TripsLog>
            {
                Includes = "Destination, Accommodation, TripActivities.Activity",
                OrderBy = t => t.StartDate
            };

            var trips = data.List(options);            
            return View(trips);
        }
    }
}
