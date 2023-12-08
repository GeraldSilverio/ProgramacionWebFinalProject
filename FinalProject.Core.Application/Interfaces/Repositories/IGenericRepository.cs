namespace FinalProject.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity,int id);
        Task<List<TEntity>> GetAllWithIncluide(List<string> properties);
    }
}
