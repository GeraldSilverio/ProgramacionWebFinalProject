using FinalProject.Core.Application.ViewModel.Case;
using FinalProject.Core.Domain.Entities;

namespace FinalProject.Core.Application.Interfaces.Services
{
    public interface ICaseServices:IGenericService<Caso,SaveCaseViewModel,CaseViewModel>
    {
        Task<MemoryStream> GenerarPDF(int Id);
    }
}
