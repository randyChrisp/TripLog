using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace TripLog.Models
{
    public class Destination
    {
        public int DestinationId { get; set; }

        [Required(ErrorMessage = "Please enter destination.")]
        public string Dest { get; set; }

        public ICollection<TripsLog> TripsLogs { get; set; }
    }
}
