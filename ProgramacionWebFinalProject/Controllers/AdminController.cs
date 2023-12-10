using FinalProject.Core.Application.Interfaces.Services;
using FinalProject.Core.Application.ViewModel.User;
using Microsoft.AspNetCore.Mvc;

namespace ProgramacionWebFinalProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ClientView()
        {
            return View(await _userService.GetAll());
        }
        #region Create
        public IActionResult CreateClient()
        {
            return View(new SaveUserViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateClient(SaveUserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var response = await _userService.Create(model);
                if (!response.HasError)
                {
                    return RedirectToAction("ClientView");
                }
                model.Error = response.Error;
                model.HasError = response.HasError;
                return View(model);

            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _userService.DeleteAsync(id);
            return RedirectToAction("ClientView");
        }

        public async Task<IActionResult> Update(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            return View("CreateClient", user);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SaveUserViewModel update)
        {
            await _userService.UpdateAsync(update, update.Id);
            return RedirectToAction("ClientView");
        }

        #endregion
    }
}
