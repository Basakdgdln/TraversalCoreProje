using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewComponents.MemberDashboard
{
    public class _LastDestinations : ViewComponent
    {
        private readonly ITravelStoriesService _travelStoriesService;
        public _LastDestinations(ITravelStoriesService travelStoriesService)
        {
            _travelStoriesService = travelStoriesService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_travelStoriesService.TGetLast4Destinations());
        }
    }
}
