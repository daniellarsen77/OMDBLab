using Microsoft.AspNetCore.Mvc;
using OMDBLab.Models;
using System.Diagnostics;

namespace OMDBLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieDAL movieAPI = new MovieDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovieSearchForm()
        {
            return View("MovieSearch");
        }
        public IActionResult MovieSearchResults(string Title)
        {
            Movie result = movieAPI.GetMovieByTitle(Title);
            return View("MovieSearch", result);
        }
        public IActionResult MovieNightForm()
        {
            return View("MovieNight");
        }
        public IActionResult MovieNightResults(string Title1, string Title2, string Title3)
        {
            List<Movie> result = movieAPI.GetThreeMovies(Title1, Title2, Title3);
            return View("MovieNight", result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}