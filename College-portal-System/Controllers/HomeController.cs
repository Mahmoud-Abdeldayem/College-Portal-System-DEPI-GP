using College_portal_System.Data.Consts;
using College_portal_System.Models;
using College_portal_System.ViewModels;
using College_portal_System.ViewModels.UserViewModels;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace College_portal_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork, ILogger<HomeController> logger, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var vm = new LoginViewModel();
            return View(vm);
        }
      
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            var role = _unitOfWork.ApplicationUserRepo.GetRole(user.Id);

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                if (role == "Student")
                {
                    _logger.LogInformation("Admin logged in.");
                    return RedirectToAction("Index", "Dashboard");
                }

                if (role == "Teaching Assisstant    ")
                {
                    _logger.LogInformation("Admin logged in.");
                    return RedirectToAction("Index", "Dashboard");
                }

                if (role == "Admin")
                {
                    _logger.LogInformation("Admin logged in.");
                    return RedirectToAction("Index", "Dashboard");
                }

                if (role == "Professor")
                {
                    _logger.LogInformation("Admin logged in.");
                    return RedirectToAction("Index", "Dashboard");
                }

                return View();
            }

            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
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
