using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View(_destinationService.TGetList());
        }
     
        public IActionResult GetCitiesSearchByName(string searchString)
        {
            ViewData["CuurentString"] = searchString;
            var values = from x in _destinationService.TGetList() select x;
            if (!string.IsNullOrEmpty(searchString))
            {
                values = values.Where(x => x.City.Contains(searchString));
            }
            return View(values.ToList());
        }
    }
}
