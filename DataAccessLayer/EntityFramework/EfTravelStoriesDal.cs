using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfTravelStoriesDal : GenericRepository<TravelStories>, ITravelStoriesDal

    {
        public TravelStories GetDestinationWithGuide(int id)
        {
            using (var c = new Context())
            {
                return c.TravelStories.Where(x => x.DestinationID == id).Include(x=>x.Guide).Include(x=>x.Destination).FirstOrDefault();
            }
        }

        public List<TravelStories> GetLast3Destinations()
        {
            using (var c = new Context())
            {
                return c.TravelStories.Include(x => x.Destination).OrderByDescending(x => x.StoriesDate).Take(3).ToList();
            }
        }

        public List<TravelStories> GetLast4Destinations()
        {
            using (var c = new Context())
            {
                return c.TravelStories.Include(x => x.Destination).OrderByDescending(x => x.StoriesDate).Take(4).ToList();
            }
        }
    }
}
