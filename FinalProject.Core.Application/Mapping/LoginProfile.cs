using AutoMapper;
using FinalProject.Core.Application.DTOs;
using FinalProject.Core.Application.ViewModel.Login;
using FinalProject.Core.Application.ViewModel.User;

namespace FinalProject.Core.Application.Mapping
{
    public class LoginProfile:Profile
    {
        public LoginProfile()
        {
            CreateMap<AutheticationRequest, LoginViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap(); 
            
            CreateMap<RegisterRequest, SaveUserViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();
                
        }
    }
}
