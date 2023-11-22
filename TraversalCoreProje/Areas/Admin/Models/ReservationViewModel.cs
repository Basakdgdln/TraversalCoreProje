using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Admin.Models
{
    public class ReservationViewModel
    {
        public int UserID { get; set; }
        public int  DestinationID { get; set; }
        public int  GuideID { get; set; }
        public int Count { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Status { get; set; }
    }
}
