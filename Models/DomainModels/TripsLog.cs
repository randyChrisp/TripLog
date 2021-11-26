using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TripLog.Models
{
    public class TripsLog
    {
        public int TripsLogId { get; set; }

        [Range(1, 99999, ErrorMessage = "Please enter destination.")]
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }

        [Required(ErrorMessage = "Please enter start date.")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Please enter end date.")]
        public DateTime? EndDate { get; set; }

        public int? AccommodationId { get; set; }
        public Accommodation Accommodation { get; set; }        

        public ICollection<TripActivity> TripActivities { get; set; }
    }
}
