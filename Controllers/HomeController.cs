using CrystalClearRecruitment_FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
//My general home controller.
namespace CrystalClearRecruitment_FinalProject.Controllers
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
            return RedirectToAction("Seek", "Jobs");
        }

        //About us 
        public IActionResult About()
        {
            return View();
        }

        //Interview Tips
        public IActionResult InterviewTips()
        {
            return View();
        }

        //Upload files
        public IActionResult UploadFiles()
        {
            return View();
        }

        //Privacy 
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
