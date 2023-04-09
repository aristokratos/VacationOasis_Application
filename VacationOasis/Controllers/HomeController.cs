using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VacationOasis.Core.Interface;
using VacationOasis.Models;

namespace VacationOasis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHotelService _hotelService;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IHotelService hotelService, IUserService userService)
        {
            _logger = logger;
            _hotelService = hotelService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Message = HttpContext.Session.GetString("userId");
            ViewBag.UserEmail = HttpContext.Session.GetString("userEmail");
            ViewBag.FullName = HttpContext.Session.GetString("userFullName");
            var hotels = await _hotelService.GetAllHotel();
            return View(hotels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewBag.Message = HttpContext.Session.GetString("userId");
            ViewBag.UserEmail = HttpContext.Session.GetString("userEmail");
            try
            {
                var hotel = await _hotelService.Details(id);
                if (HttpContext.Session.GetString("userId") != null)
                {
                    return View(hotel);
                }
                return RedirectToAction("Login", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting hotel details.");
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var userDetails = await _userService.TryAuthenticate(email, password);
                if (userDetails != null)
                {
                    HttpContext.Session.SetString("userId", userDetails.UserId);
                    HttpContext.Session.SetString("userEmail", email);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Email", "Invalid email or password.");
                }
            }
            return View("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}