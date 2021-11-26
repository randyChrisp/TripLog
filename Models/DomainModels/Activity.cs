using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripLog.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string ToDo { get; set; }

        public ICollection<TripActivity> TripActivities { get; set; }
    }
}
