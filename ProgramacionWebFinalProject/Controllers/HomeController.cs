using FinalProject.Core.Application.Enums;
using FinalProject.Core.Application.Interfaces.Services;
using FinalProject.Core.Application.ViewModel.Login;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Core.Application.Helpers;
using ProgramacionWebFinalProject.Middlewares;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using FinalProject.Core.Application.ViewModel.User;

namespace ProgramacionWebFinalProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        #region Login
        [ServiceFilter(typeof(LoginAuthorize))]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }
        [ServiceFilter(typeof(LoginAuthorize))]
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var reponse = await _userService.Authetication(model);
                if (reponse.HasError)
                {
                    model.Error = reponse.Error;
                    model.HasError = true;
                    return View(model);
                }
                HttpContext.Session.Set("user", reponse);
                if (reponse.Roles.Contains(Roles.Admin.ToString()))
                {
                    return RedirectToRoute(new { controller = "Admin", action = "ClientView" });
                }
                else
                {
                    model.Error = "Debes ser Administrador para usar la APP";
                    model.HasError = true;
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        #endregion

        public async Task<IActionResult> LogOut()
        {
            await _userService.SignOutAsync();
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index");
        }

    }
}