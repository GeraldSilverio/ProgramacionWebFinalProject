using FinalProject.Core.Application.Enums;
using FinalProject.Core.Application.Interfaces.Services;
using FinalProject.Core.Application.ViewModel.Case;
using Microsoft.AspNetCore.Mvc;

namespace ProgramacionWebFinalProject.Controllers
{
    public class CasoController : Controller
    {
        private readonly IStatusOfCaseServices statusOfCaseServices;
        private readonly ITypeOfCaseServices typeOfCaseServices;
        private readonly IUserService userService;
        private readonly ICaseServices caseServices;

        public CasoController(IStatusOfCaseServices statusOfCaseServices, ITypeOfCaseServices typeOfCaseServices, IUserService userService, ICaseServices caseServices)
        {
            this.statusOfCaseServices = statusOfCaseServices;
            this.typeOfCaseServices = typeOfCaseServices;
            this.userService = userService;
            this.caseServices = caseServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Estado = await statusOfCaseServices.GetAllAsync();
            ViewBag.Tipo = await typeOfCaseServices.GetAllAsync();
            var user = await userService.GetAll();
            ViewBag.Abogado = user.Where(x => x.Roles.Contains(Roles.Abogado.ToString()));
            ViewBag.Cliente = user.Where(x => x.Roles.Contains(Roles.Cliente.ToString()));
            return View(new SaveCaseViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveCaseViewModel saveCaseViewModel)
        {
            await caseServices.CreateAsync(saveCaseViewModel);
            return View("Index");
        }
    }
}
