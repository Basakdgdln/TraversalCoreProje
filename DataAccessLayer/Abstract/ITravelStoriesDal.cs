using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ITravelStoriesDal : IGenericDal<TravelStories>
    {
        public List<TravelStories> GetLast3Destinations();
        public List<TravelStories> GetLast4Destinations();
        public TravelStories GetDestinationWithGuide(int id);
    }
}