using AutoMapper;
using FinalProject.Core.Application.Interfaces.Repositories;
using FinalProject.Core.Application.Interfaces.Services;
using FinalProject.Core.Application.ViewModel.Case;
using FinalProject.Core.Domain.Entities;
using Microsoft.VisualBasic;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace FinalProject.Core.Application.Services
{
    public class CaseService : GenericService<Caso, SaveCaseViewModel, CaseViewModel>, ICaseServices
    {
        private readonly IUserService userService;
        private readonly ICaseRepository caseRepository;
        private readonly ITypeOfCaseServices typeOfCaseServices;
        private readonly IStatusOfCaseServices statusOfCaseServices;
        public CaseService(ICaseRepository caseRepository, IMapper mapper, IUserService userService, ITypeOfCaseServices typeOfCaseServices, IStatusOfCaseServices statusOfCaseServices) : base(caseRepository, mapper)
        {
            this.userService = userService;
            this.caseRepository = caseRepository;
            this.statusOfCaseServices = statusOfCaseServices;
            this.typeOfCaseServices = typeOfCaseServices;
        }

        public async Task<MemoryStream> GenerarPDF(int Id)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            var detalles = await GetByIdAsync(Id);

            var document = Document.Create(container =>
            container.Page(page =>
            {
                page.Margin(1, QuestPDF.Infrastructure.Unit.Centimetre);
                page.Header().AlignCenter().Text("Detalles del Caso").Bold().FontSize(20);
                page.Content().AlignCenter().Column(
                    column =>
                    {
                        column.Item().Text($"Fecha: {detalles.FechaCaso}");
                        column.Item().Text($"Nombre del Cliente: {detalles.NombreCliente}");
                        column.Item().Text($"Tipo de Caso: {detalles.NombreTipoCaso}");
                        column.Item().Text($"Ubicación: Longitud: {detalles.Longitud} y Latitud: {detalles.Latitud}");
                        column.Item().Text($"Descripción: {detalles.Descripcion}");
                        column.Item().Text($"Nombre del Abogado: {detalles.NombreAbogado}");
                        column.Item().Text($"Estado del Caso: {detalles.NombreEstadoCaso}");
                    });
            }));

            var memoryStream = new MemoryStream();
            document.GeneratePdf(memoryStream);
            memoryStream.Position = 0;

            return memoryStream;
        }


        public override async Task<List<CaseViewModel>> GetAllAsync()
        {
            var list = new List<CaseViewModel>();
            var casos = await caseRepository.GetAllAsync();

            foreach (var caso in casos)
            {
                var abogado = await userService.GetByIdAsync(caso.IdAbogado);
                var client = await userService.GetByIdAsync(caso.IdCliente);
                var tipoCaso = await typeOfCaseServices.GetByIdAsync(caso.IdTipoCaso);
                var estadoCaso = await statusOfCaseServices.GetByIdAsync(caso.IdEstadoCaso);

                var casosViewModel = new CaseViewModel()
                {
                    Id = caso.Id,
                    Descripcion = caso.Descripcion,
                    FechaCaso = caso.FechaCaso,
                    NombreAbogado = abogado.Nombre,
                    NombreCliente = client.Nombre,
                    NombreTipoCaso = tipoCaso.Nombre,
                    NombreEstadoCaso = estadoCaso.Nombre,
                    Latitud = caso.Latitud,
                    Longitud = caso.Longitud
                };

                list.Add(casosViewModel);
            }

            return list;
        }

        public override async Task<CaseViewModel> GetByIdAsync(int id)
        {
            var caso = await base.GetByIdAsync(id);
            var abogado = await userService.GetByIdAsync(caso.IdAbogado);
            var client = await userService.GetByIdAsync(caso.IdCliente);
            var tipoCaso = await typeOfCaseServices.GetByIdAsync(caso.IdTipoCaso);
            var estadoCaso = await statusOfCaseServices.GetByIdAsync(caso.IdEstadoCaso);

            var casoView = new CaseViewModel()
            {
                Id = caso.Id,
                Descripcion = caso.Descripcion,
                FechaCaso = caso.FechaCaso,
                NombreAbogado = abogado.Nombre,
                NombreCliente = client.Nombre,
                NombreTipoCaso = tipoCaso.Nombre,
                NombreEstadoCaso = estadoCaso.Nombre,
                Latitud = caso.Latitud,
                Longitud = caso.Longitud,
                IdAbogado = abogado.Id,
                IdCliente = client.Id,
                IdEstadoCaso = estadoCaso.Id,
                IdTipoCaso = tipoCaso.Id
            };

            return casoView;
        }


    }
}
