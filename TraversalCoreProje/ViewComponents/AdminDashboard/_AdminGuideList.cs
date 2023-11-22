using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewComponents.AdminDashboard
{
    public class _AdminGuideList: ViewComponent
    {
        private readonly IGuideService _guideService;
        public _AdminGuideList(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_guideService.TGetList());
        }
    }
}
