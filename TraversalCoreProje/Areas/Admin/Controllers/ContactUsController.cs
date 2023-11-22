using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;
        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            return View(_contactUsService.TGetListByTrue());
        }

        public IActionResult DeleteContactUs(int id)
        {
            var values = _contactUsService.TGetById(id);
            values.Status = false;
            _contactUsService.TDelete(values);
            return RedirectToAction("Index");
        }

        public IActionResult OpenMessage(int id)
        {
            return View(_contactUsService.TGetListByMessage(id));
        }
    }
}
