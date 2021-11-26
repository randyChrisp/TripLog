using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripLog.Models
{
    public class SelectViewModel
    {
        public IEnumerable<Destination> Destinations { get; set; }
        public IEnumerable<Accommodation> Accommodations { get; set; }
        public IEnumerable<Activity> Activities { get; set; }
    }
}
