using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewComponents.About
{
    public class _GuideListAbout : ViewComponent
    {
        private readonly IGuideService _guideService;
        public _GuideListAbout(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_guideService.TGetList());
        }
    }
}
