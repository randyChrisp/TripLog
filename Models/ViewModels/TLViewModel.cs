using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Models
{
    public class TLViewModel : SelectViewModel
    {
        public TripsLog Trip { get; set;}

        public int Page { get; set; }     
        
        public string DestName { get; set; }

        public int[] ToDoActivities { get; set; }
    }
}
