using FinalProject.Core.Application.Interfaces.Repositories;
using FinalProject.Core.Domain.Entities;
using FinalProject.Infraestructure.Persistence.Context;

namespace FinalProject.Infraestructure.Persistence.Repositories
{
    public class CaseRepository : GenericRepository<Caso>, ICaseRepository
    {
        public CaseRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
