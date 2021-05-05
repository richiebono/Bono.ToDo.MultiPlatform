using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Bono.ToDo.Web.Razor.HttpClients;
using Bono.ToDo.Web.Razor.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bono.ToDo.Web.Razor.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly AuthApiClient api;

        public AccountController(AuthApiClient api)
        {
            this.api = api;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserAuthenticateRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await api.PostLoginAsync(model);
                if (result.Succeeded)
                {
                    
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, result.User.FirstName + " " + result.User.LastName),
                        new Claim(ClaimTypes.Email, model.Email),
                        new Claim(ClaimTypes.NameIdentifier, result.User.Id.ToString()),                        
                        new Claim("Token", result.Token) 
                    };
                                        
                    var claimsIdentity = new ClaimsIdentity(
                        claims,
                        CookieAuthenticationDefaults.AuthenticationScheme
                    );

                    var authProp = new AuthenticationProperties
                    {
                        IssuedUtc = DateTime.UtcNow,                        
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(25),
                        IsPersistent = true
                    };
                                        
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProp);


                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(String.Empty, "Erro na autenticação");
                return View(model);
            }
            return View(model);

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                await api.PostRegisterAsync(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

    }
}