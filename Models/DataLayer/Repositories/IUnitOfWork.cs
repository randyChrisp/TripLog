using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripLog.Models
{
    public interface IUnitOfWork
    {
        Repository<TripsLog> Trips { get; }
        Repository<Destination> Destinations { get; }
        Repository<Accommodation> Accommodations { get; }
        Repository<Activity> Activities { get; }

        void Save();
    }
}
