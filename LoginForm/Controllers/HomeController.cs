using LoginForm.DataAccessLayer;
using LoginForm.Interfaces;
using LoginForm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text;

namespace LoginForm.Controllers
{
    public class HomeController : Controller
    {
        #region private fields
        
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private ICRUDServices _services;

        #endregion

        #region Constructor
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        /// <param name="services"></param>
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, ICRUDServices services)
        {
            _logger = logger;
            _configuration = configuration;
            _services = services;

        }

        #endregion


        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginProperties loginProperties)
        {
            loginProperties.Username = loginProperties.Username.ToLower();
            var result = await _services.CheckLoginInfoAsync(loginProperties);
            var username = result.FirstOrDefault()?.Username.ToLower();
            var password = result.FirstOrDefault()?.Password;

            if ( result != null && loginProperties.Username == username && loginProperties.Password == password)
            {
                HttpContext.Session.Set("username", Encoding.ASCII.GetBytes(loginProperties.Username));
                HttpContext.Session.Set("password", Encoding.ASCII.GetBytes(loginProperties.Password));
                
                return RedirectToAction("AdminPage", "Home");
            }
            return RedirectToAction("LoginPage", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AdminPage()
        {
            byte[] u = new byte[128];
            byte[] p = new byte[128];
            if (!HttpContext.Session.TryGetValue("username", out u) || !HttpContext.Session.TryGetValue("password", out p))
            {
                return RedirectToAction("LoginPage", "Home");
            }
            var result = await _services.GetUsersAsync();
            return View(result);
        }
        public ActionResult Register()
        {

            return View();
        }

        [HttpGet]
        public IActionResult RegistrationForm()
        {
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> Search(UserInfo userInfo)
        {
            var result = await _services.SearchUserAsync(userInfo);
            return Ok(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
