using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewComponents.AdminDashboard
{
    public class _DestinationStatistic : ViewComponent
    {
        private readonly IDestinationService _destinationService;
        public _DestinationStatistic(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetList().OrderByDescending(x=>x.Date).Take(5).ToList();
            return View(values);
        }
    }
}
