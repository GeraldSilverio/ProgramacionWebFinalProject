﻿using FinalProject.Core.Application.DTOs;
using FinalProject.Core.Application.ViewModel.Login;
using FinalProject.Core.Application.ViewModel.User;

namespace FinalProject.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<AutheticationResponse> Authetication(LoginViewModel loginViewModel);
        Task<RegisterResponse> Create(SaveUserViewModel saveUserViewModel);
        Task<List<SaveUserViewModel>> GetAll();
        Task<SaveUserViewModel> GetByIdAsync(string idUser);
        Task UpdateAsync(SaveUserViewModel request, string id);
        Task DeleteAsync(string id);
        Task SignOutAsync();
    }
}
