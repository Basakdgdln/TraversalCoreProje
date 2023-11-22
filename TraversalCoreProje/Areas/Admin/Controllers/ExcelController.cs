using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExcelController : Controller
    {
        private readonly IExcelService _excelService;
        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            using (var c = new Context())
            {
                destinationModels = c.Destinations.Select(x => new DestinationModel
                {
                    City = x.City,
                    DayNight = x.DayNight,
                    Capacity = x.Capacity,
                    Price = x.Price
                }).ToList();
            }
            return destinationModels;
        }

        public IActionResult DestinationDynamicExcelReport()
        {
            return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", " Rota Raporu.xlsx");
        }

        public List<ReservationViewModel> ReservationList()
        {
            List<ReservationViewModel> reservationModels = new List<ReservationViewModel>();
            using (var c = new Context())
            {
                reservationModels = c.Reservations.Select(x => new ReservationViewModel
                {
                    DestinationID = x.DestinationID,
                    GuideID = x.GuideID,
                    Status = x.Status,
                    Count = x.PersonCount,
                    ReservationDate = x.ReservationDate,
                    UserID = x.AppUserId
                }).ToList();
            }
            return reservationModels;
        }

        public IActionResult ReservationDynamicExcelReport()
        {
            return File(_excelService.ExcelList(ReservationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", " Rezervasyon Raporu.xlsx");
        }
    }
}
