using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface ITravelStoriesService: IGenericService<TravelStories>
    {
        public List<TravelStories> TGetLast3Destinations();
        public TravelStories GetDestinationWithGuide(int id);
        public List<TravelStories> TGetLast4Destinations();
    }
}
