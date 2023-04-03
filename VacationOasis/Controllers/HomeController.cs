using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VacationOasis.Core.Interface;
using VacationOasis.Models;

namespace VacationOasis.Controllers
{
    public class HomeController : Controller
    {
        public class HomeController : Controller
        {
            private readonly ILogger<HomeController> _logger;
            private readonly IHotelService _hotelService;
            private readonly IUserService _userServices;

            public HomeController(ILogger<HomeController> logger, IHotelService hotelService, IUserService userServices)
            {
                _logger = logger;
                _hotelService = hotelService;
                _userServices = userServices;
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
            public async Task<IActionResult> Login(UserLoginDetails user)
            {
                if (ModelState.IsValid)
                {
                    var userDetails = await _userServices.GetUserByEmail(user.Email);
                    if (userDetails != null && PasswordHasher.VerifyHashedPassword(userDetails.PasswordHash, user.Password))
                    {
                        HttpContext.Session.SetString("userId", userDetails.UserId);
                        HttpContext.Session.SetString("userEmail", user.Email);
                        HttpContext.Session.Set("userPass", userDetails.PasswordHash);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "This record does not exist in the database.");
                    }
                }
                return View(user);
            }


            [HttpGet]
            public IActionResult Login()
            {
                var userDetails = new UserLoginDetails(HttpContext.Session.GetString("userEmail"), HttpContext.Session.GetString("userPass"));
                return View(userDetails);
            }

            [HttpPost]
            public async Task<IActionResult> Login(UserLoginDetails user)
            {
                if (ModelState.IsValid)
                {
                    var userDetails = await _userServices.Login(user.Email, user.Password);
                    if (userDetails != null)
                    {
                        HttpContext.Session.SetString("userId", userDetails.UserId);
                        HttpContext.Session.SetString("userEmail", user.Email);
                        HttpContext.Session.SetString("userPass", user.Password);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "This record does not exist in the database.");
                    }
                }
                return View(user);
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
}