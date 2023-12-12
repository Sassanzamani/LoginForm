using LoginForm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoginForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        //public IActionResult LoginPage()
        //{
        //    //if (loginInfo.Username == "amir" && loginInfo.Password == "admin")
        //    //{
        //    //    return RedirectToAction("Search", "Home");
        //    //}
        //    return View();
        //}
   
        public IActionResult LoginPage()
        {
            //if (loginInfo.Username == "amir" && loginInfo.Password == "admin")
            //{
            //    return RedirectToAction("Search", "Home");
            //}
            return View();
        }


   
        public ActionResult Register()
        {

            return RedirectToAction("RegisterationForm");
        }

        [HttpGet]
        public IActionResult RegisterationForm()
        {
            return View();
        }
        [HttpGet]
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
