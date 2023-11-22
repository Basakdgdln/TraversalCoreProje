using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TraversalCoreProje.Controllers
{
    public class TraversalStoriesController : Controller
    {
        private readonly ITravelStoriesService _travelStoriesService;
        public TraversalStoriesController(ITravelStoriesService travelStoriesService)
        {
            _travelStoriesService = travelStoriesService;
        }

        public IActionResult TravelStories(int id)
        {
            ViewBag.i = id;
            ViewBag.destid = id;
            ViewBag.userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_travelStoriesService.GetDestinationWithGuide(id));
        }
    }
}
