using BookingProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookingProject.Controllers
{
    public class SearchLocationController : Controller
    {
        public async Task<IActionResult> Index(string city)
        {
            if (!string.IsNullOrEmpty(city))
            {

                var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={city}&locale=en-gb"),
                Headers =
    {
        { "X-RapidAPI-Key", "8e83fdf96emsh084418e32611491p142178jsnd3cb3be69605" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<SearchViewModel>>(body);
                return View(values.ToList());

            }
            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name=istanbul&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "8e83fdf96emsh084418e32611491p142178jsnd3cb3be69605" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<SearchViewModel>>(body);
                    return View(values.ToList());
                }
            }

        }
    }
}