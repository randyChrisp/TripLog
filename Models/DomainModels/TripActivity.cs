using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripLog.Models
{
    public class TripActivity
    {
        public int TripsLogId { get; set; }
        public int ActivityId { get; set; }

        public TripsLog TripsLog { get; set; }
        public Activity Activity { get; set; }
    }
}
