using Backend.DAL;
using Backend.Entities;
using Backend.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class AccountController:Controller
    {
        private readonly UdemyDbContext _context;
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        public AccountController(UdemyDbContext context, UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View();
            CustomUser user = await _userManager.FindByNameAsync(login.Username);

            if (user is null)
            {
                ModelState.AddModelError(string.Empty, "Username or password is incorrect");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, true);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "Due to overtrying your account has been blocked for 5 minutes");
                    return View();
                }

                ModelState.AddModelError(string.Empty, "Username or password is incorrect");
                return View();
            }

            return RedirectToAction("Index", "Home");

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM account)
        {
            if (!ModelState.IsValid) return View();
            if (!account.IsTermsAccepted)
            {
                ModelState.AddModelError("IsTermsAccepted", "You must accept our terms");
                return View();
            }

            var user = new CustomUser()
            {
                Email = account.Email,
                UserName = account.Username
            };
            IdentityResult result = await _userManager.CreateAsync(user, account.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public JsonResult ShowAuthenticatedStatus()
        {
            return Json(User.Identity.IsAuthenticated);
        }
    }
}
