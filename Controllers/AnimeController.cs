using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AnimeProject.Models;

namespace AnimeProject.Controllers
{
    public class AnimeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using var client = new HttpClient();
            string url = "https://api.jikan.moe/v4/top/anime?limit=25";
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<dynamic>(json);
            var animeList = JsonConvert.DeserializeObject<List<Anime>>(result.data.ToString());

            return View(animeList);
        }

        public async Task<IActionResult> Details(int id)
        {
            using var client = new HttpClient();
            string url = $"https://api.jikan.moe/v4/anime/{id}";
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<dynamic>(json);
            var anime = JsonConvert.DeserializeObject<Anime>(result.data.ToString());

            return View(anime);
        }

        public IActionResult Watchlist()
        {
            return View();
        }
    }
}