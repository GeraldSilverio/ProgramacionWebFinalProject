using AutoMapper;
using FinalProject.Core.Application.DTOs;
using FinalProject.Core.Application.Interfaces.Services;
using FinalProject.Core.Application.ViewModel.Login;
using FinalProject.Core.Application.ViewModel.User;

namespace FinalProject.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public UserService(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<AutheticationResponse> Authetication(LoginViewModel loginViewModel)
        {
            var login = _mapper.Map<AutheticationRequest>(loginViewModel);
            return await _accountService.Authetication(login);
        }

        public async Task<RegisterResponse> Create(SaveUserViewModel saveUserViewModel)
        {
            var request = _mapper.Map<RegisterRequest>(saveUserViewModel);
            return await _accountService.Register(request);
        }

        public async Task<List<SaveUserViewModel>> GetAll()
        {
            return await _accountService.GetAllAsync();
        }
    }
}
