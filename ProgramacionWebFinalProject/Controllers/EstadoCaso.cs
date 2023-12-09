using FinalProject.Core.Application.Interfaces.Services;
using FinalProject.Core.Application.ViewModel.StatusOfCase;
using FinalProject.Core.Application.ViewModel.TypeOfCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProgramacionWebFinalProject.Controllers
{
    public class EstadoCaso : Controller
    {
        private readonly IStatusOfCaseServices _statusOfCaseServices;

        public EstadoCaso(IStatusOfCaseServices statusOfCaseServices)
        {
            _statusOfCaseServices = statusOfCaseServices;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _statusOfCaseServices.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View(new SaveStatusOfCaseViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveStatusOfCaseViewModel model)
        {
            await _statusOfCaseServices.CreateAsync(model);
            return RedirectToAction("Index");
        }
    }
}
