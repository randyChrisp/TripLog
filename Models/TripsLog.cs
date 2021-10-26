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

        [Required(ErrorMessage = "Please enter destination.")]
        public string Dest { get; set; }

        [Required(ErrorMessage = "Please enter start date.")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Please enter end date.")]
        public DateTime? EndDate { get; set; }

        public string Acommodation { get; set; }

        public string AcommPhone { get; set; }

        public string AcommEmail { get; set; }
        public string ToDo1 { get; set; }
        public string ToDo2 { get; set; }
        public string ToDo3 { get; set; }



    }
}
