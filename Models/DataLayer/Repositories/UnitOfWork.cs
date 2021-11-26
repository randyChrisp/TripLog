﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripLog.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private TripContext context { get; set; }
        public UnitOfWork(TripContext ctx) => context = ctx;

        private Repository<TripsLog> trips;
        public Repository<TripsLog> Trips
        {
            get
            {
                if (trips ==null)
                {
                    trips = new Repository<TripsLog>(context);
                }
                return trips;
            }
        }

        private Repository<Destination> destinations;
        public Repository<Destination> Destinations
        {
            get
            {
                if (destinations == null)
                {
                    destinations = new Repository<Destination>(context);
                }
                return destinations;
            }
        }

        private Repository<Accommodation> accommodations;
        public Repository<Accommodation> Accommodations
        {
            get
            {
                if (accommodations == null)
                {
                    accommodations = new Repository<Accommodation>(context);
                }
                return accommodations;
            }
        }

        private Repository<Activity> activities;
        public Repository<Activity> Activities
        {
            get
            {
                if (activities == null)
                {
                    activities = new Repository<Activity>(context);
                }
                return activities;
            }
        }

        public void Save() => context.SaveChanges();
    }
}
