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
        
        //private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private ICRUDServices _services;
        private readonly ProjDbContext _context;

        #endregion

        #region Constructor
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        /// <param name="services"></param>
        public HomeController(ProjDbContext context, IConfiguration configuration, ICRUDServices services)
        {
            _configuration = configuration;
            _services = services;
            _context = context;            
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
            //HttpContext.Session.Remove("username");
            //HttpContext.Session.Remove("password");
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
        //public IActionResult Logout()
        //{
        //    HttpContext.Session.Remove("username");
        //    HttpContext.Session.Remove("password");
        //    return View("LoginPage", "Home");
        //}
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
        public PartialViewResult _SearchUserAsync(string? fullName, string addressString, string emailAddress, string cellPhoneNumber)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.FullName = fullName;
            userInfo.Address= addressString;
            userInfo.Email = emailAddress;
            userInfo.Tel = cellPhoneNumber;
            var searchResult = _services.SearchUserAsync(userInfo);
            return PartialView (searchResult);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
