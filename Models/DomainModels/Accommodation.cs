using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripLog.Models
{
    public class Accommodation
    {
        public int AccommodationId { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<TripsLog> TripsLogs { get; set; }
    }
}
