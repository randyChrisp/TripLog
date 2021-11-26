using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Controllers
{
    public class ManageController : Controller
    {
        private UnitOfWork data { get; set; }

        public ManageController(TripContext ctx) => data = new UnitOfWork(ctx);

        public IActionResult Index()
        {
            var tLView = new ManageViewModel();
            DropDownList(tLView);
            return View(tLView);
        }

        [HttpPost]
        public RedirectToActionResult Add(ManageViewModel tLView)
        {
            bool saveData = false;
            string confirmation = string.Empty;
            
            if(!string.IsNullOrEmpty(tLView.Destination.Dest))
            {
                data.Destinations.Insert(tLView.Destination);
                confirmation += $" {tLView.Destination.Dest} was added.";
                saveData = true;
            }

            if (!string.IsNullOrEmpty(tLView.Accommodation.Name))
            {
                data.Accommodations.Insert(tLView.Accommodation);
                confirmation += $" {tLView.Accommodation.Name} was added.";
                saveData = true;
            }

            if (!string.IsNullOrEmpty(tLView.Activity.ToDo))
            {
                data.Activities.Insert(tLView.Activity);
                confirmation += $" {tLView.Activity.ToDo} was added.";
                saveData = true;
            }

            if (saveData)
            {
                data.Save();
                TempData["message"] = confirmation;
            }

            return RedirectToAction("Notify");
        }

        [HttpPost]
        public IActionResult Delete(ManageViewModel tLView)
        {
            bool saveData = false;
            string confirmation = string.Empty;

            if (tLView.Destination.DestinationId > 0)
            {
                tLView.Destination = data.Destinations.Get(tLView.Destination.DestinationId);
                data.Destinations.Delete(tLView.Destination);
                confirmation += $" {tLView.Destination.Dest} was deleted.";
                saveData = true;
            }

            if (tLView.Accommodation.AccommodationId > 0)
            {
                tLView.Accommodation = data.Accommodations.Get(tLView.Accommodation.AccommodationId);
                data.Accommodations.Delete(tLView.Accommodation);
                confirmation += $" {tLView.Accommodation.Name} was deleted.";

                saveData = true;
            }

            if (tLView.Activity.ActivityId > 0)
            {
                tLView.Activity = data.Activities.Get(tLView.Activity.ActivityId);
                data.Activities.Delete(tLView.Activity);
                confirmation += $" {tLView.Activity.ToDo} was deleted.";
                saveData = true;
            }

            if (saveData)
            {
                try
                {
                    data.Save();
                    TempData["message"] = confirmation;
                }
                catch
                {
                    TempData["message"] = $"{tLView.Destination.Dest} has a Trip associated with it and cannot be deleted.";
                    DropDownList(tLView);
                }
            }
            return RedirectToAction("Notify");
        }

        public ViewResult Notify()
        {
            return View();
        }

        private void DropDownList(ManageViewModel tLView)
        {
            tLView.Destinations = data.Destinations.List(new QueryOptions<Destination>
            {
                OrderBy = d => d.Dest
            });

            tLView.Accommodations = data.Accommodations.List(new QueryOptions<Accommodation>
            {
                OrderBy = a => a.Name
            });

            tLView.Activities = data.Activities.List(new QueryOptions<Activity>
            {
                OrderBy = a => a.ToDo
            });
        }
    }
}
