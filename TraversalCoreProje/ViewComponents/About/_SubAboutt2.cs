using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewComponents.About
{
    public class _SubAboutt2 : ViewComponent
    {
        SubAboutManager sb = new SubAboutManager(new EfSubAboutDal());
        public IViewComponentResult Invoke()
        {
            return View(sb.TGetList());
        }
    }
}
