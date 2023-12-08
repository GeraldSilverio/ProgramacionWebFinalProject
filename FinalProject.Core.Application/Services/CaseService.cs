using AutoMapper;
using FinalProject.Core.Application.Interfaces.Repositories;
using FinalProject.Core.Application.Interfaces.Services;
using FinalProject.Core.Application.ViewModel.Case;
using FinalProject.Core.Domain.Entities;

namespace FinalProject.Core.Application.Services
{
    public class CaseService : GenericService<Caso, SaveCaseViewModel, CaseViewModel>, ICaseServices
    {
        public CaseService(IGenericRepository<Caso> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
