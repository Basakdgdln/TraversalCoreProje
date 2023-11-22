using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _Feature: ViewComponent
    {
        FeatureManager fm = new FeatureManager(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
           // ViewBag.image1= fm.ge
            return View();
        }
    }
}
