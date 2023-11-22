using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Guide")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;
        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View(_guideService.TGetList());
        }

        [Route("AddGuide")]
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [Route("AddGuide")]
        [HttpPost]
        public IActionResult AddGuide(Guide p)
        {
            GuideValidator validationRules = new GuideValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                p.Status = true;
                _guideService.TAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }


        [Route("EditGuide/{id}")]
        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var values = _guideService.TGetById(id);
            return View(values);
        }

        [Route("EditGuide/{id}")]
        [HttpPost]
        public IActionResult EditGuide(Guide p)
        {
            _guideService.TUpdate(p);
            return RedirectToAction("Index");
        }

        [Route("ChangeToTrue/{id}")]
        public IActionResult ChangeToTrue(int id)
        {
            _guideService.TChangeToTrueByGuide(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }

        [Route("ChangeToFalse/{id}")]
        public IActionResult ChangeToFalse(int id)
        {
            _guideService.TChangeToFalseByGuide(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
    }
}
