using FinalProject.Core.Application.DTOs;
using FinalProject.Core.Application.ViewModel.User;

namespace FinalProject.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<RegisterResponse> Register(RegisterRequest request);
        Task<AutheticationResponse> Authetication(AutheticationRequest request);
        Task<List<SaveUserViewModel>> GetAllAsync();
        Task<SaveUserViewModel> GetByIdAsync(string idUser);
        Task UpdateAsync(SaveUserViewModel request, string id);
        Task DeleteAsync(string id);
    }
}
