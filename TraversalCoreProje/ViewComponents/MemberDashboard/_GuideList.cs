using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewComponents.MemberDashboard
{
    public class _GuideList: ViewComponent
    {
        GuideManager gm = new GuideManager(new EfGuideDal());
        public IViewComponentResult Invoke()
        {
            return View(gm.TGetList());
        }
    }
}
