using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using TraversalCoreProje.Areas.Admin.Models;
using Newtonsoft.Json;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    public class ApiExchangeController : Controller
    {
        [Area("Admin")]
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
                Headers =
    {
        { "X-RapidAPI-Key", "50d736f00emshae52e7a40209d1cp12adf1jsne0f5f27cea30" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BookingExchangeViewModel2>(body);
                return View(values.exchange_rates);
            }
        }
    }
}
