using LoginForm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoginForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult LoginPage(LoginProperties loginInfo)
        {
            //if (loginInfo.Username.ToLower() == "amir" && loginInfo.Password.ToLower() == "admin")
            //{
            //    return RedirectToAction("Search", "Home");
            //}
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Search()
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
