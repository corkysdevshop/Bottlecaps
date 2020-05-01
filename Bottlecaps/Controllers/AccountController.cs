using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Bottlecaps.Models.AccountViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Bottlecaps.Controllers
{
    //[Route("Account/[controller]")]
    //[ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(
            UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public class IdentityProviderCredentials // TODO: MAKE THIS AN ACTUAL IDENTITY PROVIDER THAT ENCRYPTS IN TRANSIT WITH CERTIFICATES
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        // TODO: FIGURE OUT HOW TO GET REGISTER USER WITH IDENTITY MANAGER
        //POST: /Account/Register
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] IdentityProviderCredentials model)
        {

            IdentityUser user = new IdentityUser()
            {
                Email = model.Email,
                UserName = model.Email //TODO: VALIDATION
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            //If we got this far, something failed, redisplay form
            await _signInManager.SignInAsync(user, isPersistent: false);

            var jwt = new JwtSecurityToken();

            return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
            /*
            var user = new IdentityUser { UserName = credentials.Email, Email = credentials.Email };

            var result = await userManager.CreateAsync(user, credentials.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await signInManager.SignInAsync(user, isPersistent: false);

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is the secret phrase"));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            */
        }

        //POST: /Account/Login
       [HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        public IActionResult Login(IdentityProviderCredentials model)
        {
            //var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            //if (result.Succeeded)
            //{
            //    if (Url.IsLocalUrl(returnUrl))
            //    {
            //        return Redirect(returnUrl);
            //    }
            //    else
            //    {
            //        return RedirectToAction(nameof(StudentController.Index), "Student");
            //    }

            //}
            //else
            //{
            //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            //}

            // If we got this far, something failed, redisplay form
            //return View(model); //TODO: RETURN JWT AUTHENTICATION TOKEN FROM IDENTITY PROVIDER
            //return Content("logged in");
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is the secret phrase"));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken();

            return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
        }

        // GET: /Account/Register
        //[HttpGet]
        //public IActionResult Register()
        //{
        //    return Content("returned data from Register method");
        //}

        // GET: /Account/Login
        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        //
        // POST: /Account/Logout
        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    return RedirectToAction(nameof(HomeController.Index), "Home");
        //}
        //[HttpGet]
        //public IActionResult AccessDenied()
        //{
        //    return View();
        //}
    }
}