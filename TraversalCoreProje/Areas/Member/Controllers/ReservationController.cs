using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        ReservationManager rm = new ReservationManager(new EfReservationDal());
        public IActionResult MyCurrentReservation()
        {
            var user = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.count = rm.GetListAcceptedReservation(user).Count();
            return View(rm.GetListAcceptedReservation(user));
        }
        public IActionResult MyOldReservation()
        {
            var user = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.count = rm.GetListPreviousReservation(user).Count();
            return View(rm.GetListPreviousReservation(user));
        }
        public IActionResult MyApprovalReservation()
        {
            var user = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.count = rm.GetListApprovalReservation(user).Count();
            return View(rm.GetListApprovalReservation(user));
        }


        [HttpGet]
        public IActionResult NewReservation()
        {
            DestinationManager dm = new DestinationManager(new EfDestinationDal());
            ViewBag.v = new SelectList(dm.TGetList(), "DestinationID".ToString(), "City", "1");
            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Reservation p)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            p.Status = "Onay Bekliyor";
            p.AppUserId = int.Parse(user);
            rm.TAdd(p);
            return RedirectToAction("MyCurrentReservation");
        }

    }
}
