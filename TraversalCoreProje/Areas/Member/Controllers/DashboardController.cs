using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> MemberDashboard()
        {
            var username = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.user = username.Name + " " + username.Surname;
            ViewBag.image = username.ImageUrl;
            return View();
        }
    }
}
