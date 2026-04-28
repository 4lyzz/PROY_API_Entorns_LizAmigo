using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using CatsApp.Models;

namespace CatsApp.Controllers
{
    public class BunnyController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();

            var json = await client.GetStringAsync("https://api.bunnies.io/v2/loop/random/?media=gif,png");
            var data = JObject.Parse(json);

            var bunny = new Bunny
            {
                url = data["media"]["gif"].ToString()
            };

            return View(bunny);
        }
    }
}