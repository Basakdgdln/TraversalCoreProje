using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VisitorApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public VisitorApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("http://localhost:34212/api/Visitor");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsondata);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddVisitor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddVisitor(VisitorViewModel p)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsemmessage = await client.PostAsync("http://localhost:34212/api/Visitor", content);
            if (responsemmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemmessage = await client.DeleteAsync($"http://localhost:34212/api/Visitor/{id}");
            if (responsemmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemmessage = await client.GetAsync($"http://localhost:34212/api/Visitor/{id}");
            if (responsemmessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemmessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<VisitorViewModel>(jsondata);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> EditVisitor(VisitorViewModel p)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsemmessage =await client.PutAsync("http://localhost:34212/api/Visitor", content);
            if (responsemmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
