using LoginForm.Interfaces;
using LoginForm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoginForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private ICRUDServices _services;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration,ICRUDServices services)
        {
            _logger = logger;
            _configuration = configuration;
            _services = services;
        }

        //public IActionResult LoginPage()
        //{
        //    //if (loginInfo.Username == "amir" && loginInfo.Password == "admin")
        //    //{
        //    //    return RedirectToAction("Search", "Home");
        //    //}
        //    return View();
        //}
        [HttpGet]
        public IActionResult LoginPage(LoginProperties loginProperties)
        {

            if (loginProperties.Username == "amir" && loginProperties.Password == "admin")
            {
                return RedirectToAction("Search", "Home");
            }

            return View();
        }
        [HttpPost]
        public IActionResult LoginPage(LoginProperties loginProperties)
        {
                var result = await _services.GetUsersAsync();
                return View(result);



            return View();
        }


        public ActionResult Register()
        {

            return RedirectToAction("RegistrationForm");
        }

        [HttpGet]
        public IActionResult RegistrationForm()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Search()
        {

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
