using System.Security.Claims;
using ChopShop.Api.Dal.UserContext;
using ChopShop.Api.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChopShop.Api.Controllers
{
    public class AccountController : Controller
    {
        private UserContext _userContext;
        public AccountController(UserContext context)
        {
            _userContext = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Email); // аутентификация
 
                    return RedirectToAction("Get", "Menu");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var user = await _userContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
            {
                _userContext.Users.Add(new User { Email = model.Email, Password = model.Password });
                await _userContext.SaveChangesAsync();
 
                await Authenticate(model.Email);
 
                return RedirectToAction("Get", "Menu");
            }
            
            ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            return View(model);
        }
 
        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new (ClaimsIdentity.DefaultNameClaimType, userName)
            };
            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
 
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}