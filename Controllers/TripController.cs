using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Controllers
{
    public class TripController : Controller
    {
        private TripContext context { get; set; }

        public TripController(TripContext ctx)
        {
            context = ctx;
        }

        public RedirectToActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public RedirectToActionResult Clear()
        {
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ViewResult Add(string id)
        {
            TLViewModel tLView = new TLViewModel();

            switch (id?.ToLower())
            {
                case "page2":

                    string accomm = TempData[nameof(TripsLog.Acommodation)]?.ToString();

                    if (string.IsNullOrWhiteSpace(accomm))
                    {
                        tLView.Page = 3;
                        string destination = TempData.Peek(nameof(TripsLog.Dest)).ToString();
                        tLView.Trip = new TripsLog { Dest = destination };
                        return View("Page3", tLView);
                    }

                    tLView.Page = 2;
                    tLView.Trip = new TripsLog { Acommodation = accomm };
                    TempData.Keep(nameof(TripsLog.Acommodation));
                    return View("Page2", tLView);

                case "page3":

                    tLView.Page = 3;
                    tLView.Trip = new TripsLog { Dest = TempData.Peek(nameof(TripsLog.Dest)).ToString() };
                    return View("Page3", tLView);

                case "page1":
                default:
                    tLView.Page = 1;
                    return View("Page1", tLView);                   
            }

        }

        [HttpPost]
        public IActionResult Add(TLViewModel tLView)
        {
            switch (tLView.Page)
            {
                case 1:
                    if (!ModelState.IsValid)
                    {
                        return View("Page1", tLView);
                    }

                    TempData[nameof(TripsLog.Dest)] = tLView.Trip.Dest;
                    TempData[nameof(TripsLog.Acommodation)] = tLView.Trip.Acommodation;
                    TempData[nameof(TripsLog.StartDate)] = tLView.Trip.StartDate;
                    TempData[nameof(TripsLog.EndDate)] = tLView.Trip.EndDate;

                    return RedirectToAction("Add", new { id = "Page2" });

                case 2:
                    TempData[nameof(TripsLog.AcommPhone)] = tLView.Trip.AcommPhone;
                    TempData[nameof(TripsLog.AcommEmail)] = tLView.Trip.AcommEmail;
                    return RedirectToAction("Add", new { id = "Page3" });

                case 3:
                    tLView.Trip.Dest = TempData[nameof(TripsLog.Dest)].ToString();
                    tLView.Trip.Acommodation = TempData[nameof(TripsLog.Acommodation)]?.ToString();
                    tLView.Trip.StartDate = (DateTime)TempData[nameof(TripsLog.StartDate)];
                    tLView.Trip.EndDate = (DateTime)TempData[nameof(TripsLog.EndDate)];
                    tLView.Trip.AcommPhone = TempData[nameof(TripsLog.AcommPhone)]?.ToString();
                    tLView.Trip.AcommEmail = TempData[nameof(TripsLog.AcommEmail)]?.ToString();

                    context.Trips.Add(tLView.Trip);
                    context.SaveChanges();
                    TempData["message"] = "Trip to " + tLView.Trip.Dest + " added.";
                    return RedirectToAction("Index", "Home");

                default:
                    return RedirectToAction("Index", "Home");
            }
        }
    }
}
