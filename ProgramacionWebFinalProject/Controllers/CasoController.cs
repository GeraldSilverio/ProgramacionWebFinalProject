using AutoMapper;
using FinalProject.Core.Application.Enums;
using FinalProject.Core.Application.Interfaces.Services;
using FinalProject.Core.Application.Services;
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
        private readonly IMapper mapper;

        public CasoController(IStatusOfCaseServices statusOfCaseServices, ITypeOfCaseServices typeOfCaseServices, IUserService userService, ICaseServices caseServices, IMapper mapper)
        {
            this.statusOfCaseServices = statusOfCaseServices;
            this.typeOfCaseServices = typeOfCaseServices;
            this.userService = userService;
            this.caseServices = caseServices;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {            
            return View(await caseServices.GetAllAsync());
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


        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Estado = await statusOfCaseServices.GetAllAsync();
            ViewBag.Tipo = await typeOfCaseServices.GetAllAsync();
            var user = await userService.GetAll();
            ViewBag.Abogado = user.Where(x => x.Roles.Contains(Roles.Abogado.ToString()));
            ViewBag.Cliente = user.Where(x => x.Roles.Contains(Roles.Cliente.ToString()));
            SaveCaseViewModel editCase = mapper.Map<SaveCaseViewModel>(await caseServices.GetByIdAsync(id));           
            return View("Create", editCase);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SaveCaseViewModel saveCaseViewModel, int id)
        {
            await caseServices.UpdateAsync(saveCaseViewModel, id);           
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DownloadCasePDF(int id)
        {
            var pdfStream = await caseServices.GenerarPDF(id);
            if (pdfStream == null)
            {
                return NotFound();
            }

            pdfStream.Position = 0;

            return File(pdfStream, "application/pdf", $"case_{id}.pdf");
        }
    }
}
