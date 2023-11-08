using Microsoft.AspNetCore.Mvc;
using ProbabilityTheoryTask.Models;
using System.Diagnostics;

namespace ProbabilityTheoryTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult StandartFormulas()
        //{
        //    return View();
        //}

        public IActionResult StandartFormulas(SimpleProbabilityCalculation simpleProbabilityCalculation)
        {
            simpleProbabilityCalculation.CalculateAll();
            return View(simpleProbabilityCalculation);
        }

        public IActionResult UrnaFormulas(UrnaModelCalculation urnaModelCalculation)
        {
            urnaModelCalculation.Calculate();
            return View(urnaModelCalculation);
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