using AutoMapper;
using FinalProject.Core.Application.Interfaces.Repositories;
using FinalProject.Core.Application.Interfaces.Services;
using FinalProject.Core.Application.ViewModel.TypeOfCase;
using FinalProject.Core.Domain.Entities;

namespace FinalProject.Core.Application.Services
{
    public class TypeOfCaseServices : GenericService<TipoCaso, SaveTypeOfCaseViewModel, TypeOfCaseViewModel>, ITypeOfCaseServices
    {
        public TypeOfCaseServices(IGenericRepository<TipoCaso> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
