using FinalProject.Core.Application.Interfaces.Repositories;
using FinalProject.Core.Domain.Entities;
using FinalProject.Infraestructure.Persistence.Context;

namespace FinalProject.Infraestructure.Persistence.Repositories
{
    public class TypeOfCaseRepository : GenericRepository<TipoCaso>, ITypeOfCaseRepository
    {
        public TypeOfCaseRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
