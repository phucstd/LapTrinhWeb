﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Text.Encodings.Web;
using System.Text;
using TheWayShop.AppData;
using TheWayShop.Models;
using Microsoft.AspNetCore.Mvc.Routing;

namespace TheWayShop.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserStore<AppUser> _userStore;
        //private readonly IUserEmailStore<AppUser> _emailStore;
        public UserController(UserManager<AppUser> userManager,IUserStore<AppUser> userStore, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            //_emailStore = emailStore;
          
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Login", "Dang nhap khong thanh cong");
                    return View();
                }
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();
                user.Address = model.Address;
                user.FirstName  = model.FirstName;
                user.LastName = model.LastName;
                await _userStore.SetUserNameAsync(user, model.Email, CancellationToken.None);
                //await _emailStore.SetEmailAsync(user, model.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    /*
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                    */
                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = model.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterFromCheckout(CheckoutViewModel model, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var user = CreateUser();
            user.Address = model.Register.Address;
            user.FirstName = model.Register.FirstName;
            user.LastName = model.Register.LastName;
            await _userStore.SetUserNameAsync(user, model.Register.Email, CancellationToken.None);
            //await _emailStore.SetEmailAsync(user, model.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, model.Register.Password);

            if (result.Succeeded)
            {
                // _logger.LogInformation("User created a new account with password.");

                var userId = await _userManager.GetUserIdAsync(user);
                /*
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                    protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                */
                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    return RedirectToPage("RegisterConfirmation", new { email = model.Register.Email, returnUrl = returnUrl });
                }
                else
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToRoute("checkout");
                }
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            // If we got this far, something failed, redisplay form
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginFromCheckout(CheckoutViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Login.Email, model.Login.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("Login", "Dang nhap khong thanh cong");
            }
            return RedirectToRoute("checkout");
        }
        private AppUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<AppUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(AppUser)}'. " +
                    $"Ensure that '{nameof(AppUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
