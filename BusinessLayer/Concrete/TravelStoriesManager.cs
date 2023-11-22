using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{

    public class TravelStoriesManager : ITravelStoriesService
    {
      ITravelStoriesDal _travelStoriesDal;
        public TravelStoriesManager(ITravelStoriesDal travelStoriesDal)
        {
            _travelStoriesDal = travelStoriesDal;
        }

        public TravelStories GetDestinationWithGuide(int id)
        {
            return _travelStoriesDal.GetDestinationWithGuide(id);
        }

        public void TAdd(TravelStories t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(TravelStories t)
        {
            throw new NotImplementedException();
        }

        public TravelStories TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<TravelStories> TGetLast3Destinations()
        {
            return _travelStoriesDal.GetLast3Destinations();
        }

        public List<TravelStories> TGetLast4Destinations()
        {
            return _travelStoriesDal.GetLast4Destinations();
        }

        public List<TravelStories> TGetList()
        {
            return _travelStoriesDal.GetList();
        }

        public void TUpdate(TravelStories t)
        {
            throw new NotImplementedException();
        }
    }
}
