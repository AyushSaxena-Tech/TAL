using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TAL.Models;

namespace TAL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                string rating = _configuration.GetSection("Occupation").GetSection(userModel.Occupation.ToString()).Value;
                double factor = Convert.ToDouble(_configuration.GetSection("OccupationRating").GetSection(rating).Value);
                ViewBag.DeathPremium = (userModel.DeathSum * factor * userModel.Age) / 1000 * 12;
                ModelState.Clear();

                return View();
            }
            return View(userModel);
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