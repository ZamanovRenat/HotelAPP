using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelAPP.Context;
using HotelAPP.Domain.Entities;
using HotelAPP.Domain.Entities.Identity;
using HotelAPP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace HotelAPP.Controllers
{
    public class AccountController : Controller
    {
        private readonly HotelContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            HotelContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<AccountController> logger)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        #region Register
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterClientViewModel());
        }
        [AllowAnonymous]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterClientViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            
            //Переменная пользователя
            var user = new User
            {
                UserName = model.UserName
            };
            _logger.LogInformation("Регистрация нового клиента {0}", model.UserName);

            //Создание нового пользователя через UserManager
            var register_result = await _userManager.CreateAsync(user, model.Password);
            
            //При успешном создании пользователя вход в приложение на главную страницу
            if (register_result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);

                _logger.LogInformation("Пользователь {0} успешно зарегистрирован", user.UserName);

                return RedirectToAction("Index", "Home");
            }

            //Если при создании пользователя произшла ошибка, происходит сбор ошибок в ModelState 
            foreach (var error in register_result.Errors)
                ModelState.AddModelError("", error.Description);

            _logger.LogWarning("Ошибка при регистрации пользователя {0} в систему: {1}",
                model.UserName,
                string.Join(", ", register_result.Errors.Select(err => err.Description)));
            
            //Отображение модели с ошибками
            return View(model);
        }
        #endregion

        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = ReturnUrl });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //Если вход успешный возвращем вид
            if (!ModelState.IsValid) return View(model);

            //При успешной проверке пароля вход через SignInManager по паролю
            var login_result = await _signInManager.PasswordSignInAsync(
                model.UserName,
                model.Password,
                model.RememberMe,
                //При отладке не учитываются не верные попытки ввода кода
#if DEBUG
                false
#else
                true
#endif
            );

            //При успешном входе пользователя, происходит его перенаправление
            if (login_result.Succeeded)
            {
                return LocalRedirect(model.ReturnUrl ?? "/");
            }

            //При неуспешном будет выводиться сообщение
            ModelState.AddModelError("", "Ошибка в имени пользователя, либо в пароле");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccesDenied() => View();
    }
}
