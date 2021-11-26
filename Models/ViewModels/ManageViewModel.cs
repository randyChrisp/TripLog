using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripLog.Models
{
    public class ManageViewModel : SelectViewModel
    {
        public Destination Destination { get; set; }
        public Accommodation Accommodation { get; set; }
        public Activity Activity { get; set; }
    }
}
