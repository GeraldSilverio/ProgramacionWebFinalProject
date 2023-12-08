using FinalProject.Core.Application.Interfaces.Services;
using FinalProject.Core.Application.ViewModel.TypeOfCase;
using Microsoft.AspNetCore.Mvc;

namespace ProgramacionWebFinalProject.Controllers
{
    public class TipoCasoController : Controller
    {
        private readonly ITypeOfCaseServices _typeOfCaseServices;

        public TipoCasoController(ITypeOfCaseServices typeOfCaseServices)
        {
            _typeOfCaseServices = typeOfCaseServices;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _typeOfCaseServices.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View(new SaveTypeOfCaseViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveTypeOfCaseViewModel model)
        {
            await _typeOfCaseServices.CreateAsync(model);
            return RedirectToAction("Index");
        }
    }
}
