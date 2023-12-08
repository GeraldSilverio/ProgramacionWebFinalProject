using FinalProject.Core.Application.Interfaces.Repositories;
using FinalProject.Core.Domain.Entities;
using FinalProject.Infraestructure.Persistence.Context;

namespace FinalProject.Infraestructure.Persistence.Repositories
{
    public class StatusOfCaseRepository : GenericRepository<EstadoCaso>, IStatusOfCaseRepository
    {
        public StatusOfCaseRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
