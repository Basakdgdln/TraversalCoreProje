using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfileContoller : Controller
    {
        private readonly IAdminService _adminService;
        public ProfileContoller(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var profile = _adminService.TGetById(user);
            return View(profile);
        }

        [HttpPost]
        public IActionResult Index(EntityLayer.Concrete.Admin p)
        {
            _adminService.TUpdate(p);
            return View("Index");
        }

    }
}
