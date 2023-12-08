namespace FinalProject.Core.Application.Interfaces.Services
{
    public interface IGenericService<Model, SaveViewModel, ViewModel>
        where Model : class
        where SaveViewModel : class
        where ViewModel : class
    {
        Task<SaveViewModel> CreateAsync(SaveViewModel model);
        Task UpdateAsync(SaveViewModel model, int id);
        Task DeleteAsync(int id);
        Task<List<ViewModel>> GetAllAsync();
        Task<ViewModel> GetByIdAsync(int id);
    }
}
