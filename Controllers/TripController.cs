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
        private UnitOfWork data { get; set; }
        public TripController(TripContext ctx)
        {
            data = new UnitOfWork(ctx);
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
        public ViewResult Add(string id = "")
        {
            TLViewModel tLView = new TLViewModel();

            switch (id.ToLower())
            {
                case "page2":

                    tLView.Page = 2;
                    int destinationId = (int)TempData.Peek(nameof(TripsLog.DestinationId));
                    tLView.DestName = data.Destinations.Get(destinationId).Dest;

                    tLView.Activities = data.Activities.List(new QueryOptions<Activity>
                    {
                        OrderBy = a => a.ToDo
                    }); 
                    
                    return View("Page2", tLView);                

                case "page1":
                default:
                    tLView.Page = 1;
                    tLView.Destinations = data.Destinations.List(new QueryOptions<Destination>
                    { 
                        OrderBy = d => d.Dest
                    });

                    tLView.Accommodations = data.Accommodations.List(new QueryOptions<Accommodation>
                    {
                        OrderBy = a => a.Name
                    });
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
                        tLView.Destinations = data.Destinations.List(new QueryOptions<Destination>
                        {
                            OrderBy = d => d.Dest
                        });
                        tLView.Accommodations = data.Accommodations.List(new QueryOptions<Accommodation>
                        {
                            OrderBy = a => a.Name
                        });

                        return View("Page1", tLView);
                    }

                    TempData[nameof(TripsLog.DestinationId)] = tLView.Trip.DestinationId;
                    TempData[nameof(TripsLog.StartDate)] = tLView.Trip.StartDate;
                    TempData[nameof(TripsLog.EndDate)] = tLView.Trip.EndDate;
                    TempData[nameof(TripsLog.AccommodationId)] = (tLView.Trip.AccommodationId.HasValue && tLView.Trip.AccommodationId.Value > 0)
                        ? tLView.Trip.AccommodationId : 0;

                    return RedirectToAction("Add", new { id = "Page2" });

                case 2:

                    tLView.Trip = new TripsLog
                    {
                        DestinationId = (int)TempData[nameof(TripsLog.DestinationId)],
                        StartDate = (DateTime)TempData[nameof(TripsLog.StartDate)],
                        EndDate = (DateTime)TempData[nameof(TripsLog.EndDate)],
                        AccommodationId = (int)TempData[nameof(TripsLog.AccommodationId)]

            };

                    if(tLView.Trip.AccommodationId <= 0)
                    {
                        tLView.Trip.AccommodationId = null;
                    }

                    if (tLView.ToDoActivities != null)
                    {
                        foreach (int activityId in tLView.ToDoActivities)
                        {
                            if (tLView.Trip.TripActivities == null)
                            {
                                tLView.Trip.TripActivities = new List<TripActivity>();
                            }

                            tLView.Trip.TripActivities.Add(new TripActivity { ActivityId = activityId });
                        }
                    }

                    data.Trips.Insert(tLView.Trip);
                    data.Save();

                    Destination destination = data.Destinations.Get(tLView.Trip.DestinationId);

                    
                    TempData["message"] = $"Trip to {destination.Dest} was added.";
                    return RedirectToAction("Index", "Home");

                default:
                    return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public RedirectToActionResult Delete(int id)
        {
            TripsLog trip = data.Trips.Get(id);
            Destination destination = data.Destinations.Get(trip.DestinationId);

            data.Trips.Delete(trip);
            data.Save();

            TempData["message"] = $"Trip to {destination.Dest} has been deleted.";
            return RedirectToAction("Index", "Home");
        }
    }
}
