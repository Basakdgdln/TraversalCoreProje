using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
  public  class TravelStories
    {
        [Key]
        public int StoriesID { get; set; }
        public string CoverImage { get; set; }
        public string Details1 { get; set; }
        public string Details2 { get; set; }
        public string Image2 { get; set; }
        public string Quotes { get; set; }
        public string Writer { get; set; }
        public DateTime StoriesDate { get; set; }

        public int? GuideID { get; set; }
        public Guide Guide { get; set; }

        public int DestinationID { get; set; }
        public Destination Destination { get; set; }

    }
}
