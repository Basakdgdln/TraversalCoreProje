using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewComponents.About
{
    public class _Last3DestinationAbout: ViewComponent
    {
        private readonly ITravelStoriesService _travelStoriesService;
        public _Last3DestinationAbout(ITravelStoriesService travelStoriesService)
        {
            _travelStoriesService = travelStoriesService;
      
        }

        public IViewComponentResult Invoke()
        {
            TravelStoriesManager tm = new TravelStoriesManager(new EfTravelStoriesDal());
            
            return View(tm.TGetLast3Destinations());
        }
    }
}
