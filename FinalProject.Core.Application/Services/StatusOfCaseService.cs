using AutoMapper;
using FinalProject.Core.Application.Interfaces.Repositories;
using FinalProject.Core.Application.Interfaces.Services;
using FinalProject.Core.Application.ViewModel.StatusOfCase;
using FinalProject.Core.Domain.Entities;

namespace FinalProject.Core.Application.Services
{
    public class StatusOfCaseService : GenericService<EstadoCaso, SaveStatusOfCaseViewModel, StatusOfCaseViewModel>, IStatusOfCaseServices
    {
        public StatusOfCaseService(IGenericRepository<EstadoCaso> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
