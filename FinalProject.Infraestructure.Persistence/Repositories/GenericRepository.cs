using FinalProject.Core.Application.Interfaces.Repositories;
using FinalProject.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infraestructure.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _dbContext;
        protected DbSet<TEntity> Entities => _dbContext.Set<TEntity>();

        public GenericRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(TEntity entity)
        {
            Entities.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Entities.FindAsync(id);
        }
        public async Task UpdateAsync(TEntity entity, int id)
        {
            var entry = await Entities.FindAsync(id);
            _dbContext.Entry(entry).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<TEntity>> GetAllWithIncluide(List<string> properties)
        {
            var query = Entities.AsQueryable();
            foreach(string property in properties)
            {
                query = query.Include(property);
            }
            return await query.ToListAsync();
        }
    }
}
