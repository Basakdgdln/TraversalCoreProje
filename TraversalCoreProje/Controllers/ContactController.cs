using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DtoLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SendMessageDto model)
        {
            if (ModelState.IsValid)
            {
                _contactUsService.TAdd(new ContactUs()
                {
                    Mail = model.Mail,
                    MessageBody = model.MessageBody,
                    Name = model.Name,
                    Subject = model.Subject,
                    Status = true,
                    MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                });
                return RedirectToAction("Index", "Default");
            }
            return View(model);
        }
    }
}
