﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Identity;
using WebStore.Domain.ViewModels;

namespace WebStore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _SignInManager;
        private readonly ILogger<AccountController> _Logger;
        public AccountController(UserManager<User> UserManager, SignInManager<User> SignInManager, ILogger<AccountController> Logger)
        {
            _UserManager = UserManager;
            _SignInManager = SignInManager;
            _Logger = Logger;
        }

        [AllowAnonymous]
        public IActionResult LoginRegister() => View(new LoginRegisterViewModel());

        #region Register
        [AllowAnonymous]
        public IActionResult Register() => View(new RegisterUserViewModel());

        [AllowAnonymous]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterUserViewModel Model)
        {
            if (!ModelState.IsValid) return View(Model);

            _Logger.LogInformation("Регистрация пользователя {0}", Model.UserName);

            var user = new User
            {
                UserName = Model.UserName
            };

            using (_Logger.BeginScope("Регистрация пользователя {0}", Model.UserName))
            {
                var registration_result = await _UserManager.CreateAsync(user, Model.Password);
                if (registration_result.Succeeded)
                {
                    await _UserManager.AddToRoleAsync(user, Role.Users);

                    _Logger.LogInformation("Пользователь {0} успешно зарегистрирован", Model.UserName);

                    await _SignInManager.SignInAsync(user, false);

                    return RedirectToAction("Index", "Home");
                }

                _Logger.LogWarning("В процессе регистрации пользователя {0} возникли ошибки {1}",
                    Model.UserName,
                    string.Join(", ", registration_result.Errors.Select(e => e.Description)));

                foreach (var error in registration_result.Errors)
                    ModelState.AddModelError("", error.Description);
            }

            return View(Model);
        }
        #endregion

        #region Login
        [AllowAnonymous]
        public IActionResult Login(string ReturnUrl) => View(new LoginViewModel { ReturnUrl = ReturnUrl });

        [AllowAnonymous]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Login")]
        public async Task<IActionResult> LoginAsync(LoginViewModel Model)
        {
            if (!ModelState.IsValid) return View(Model);

            var login_result = await _SignInManager.PasswordSignInAsync(
                Model.UserName,
                Model.Password,
                Model.RememberMe,
#if DEBUG
                        false
#else
                        true
#endif
                        );

            if (login_result.Succeeded)
            {
                return LocalRedirect(Model.ReturnUrl ?? "/");
                // Аналогично предыдущему.
                //if (Url.IsLocalUrl(Model.ReturnUrl))
                //    return Redirect(Model.ReturnUrl);
                //return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Неверное имя пользователя, или пароль!");

            return View(Model);
        }
            #endregion

            [ActionName("Logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

    }
}
