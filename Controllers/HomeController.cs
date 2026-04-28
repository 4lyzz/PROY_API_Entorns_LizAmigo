using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using CatsApp.Models;

namespace CatsApp.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = new HttpClient();

        var json = await client.GetStringAsync("https://api.thecatapi.com/v1/images/search");
        var data = JArray.Parse(json);

        var cat = new Cat
        {
            url = data[0]["url"].ToString()
        };

        return View(cat);
    }
}