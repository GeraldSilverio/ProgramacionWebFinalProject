using AutoMapper;
using FinalProject.Core.Application.DTOs;
using FinalProject.Core.Application.ViewModel.Login;
using FinalProject.Core.Application.ViewModel.StatusOfCase;
using FinalProject.Core.Application.ViewModel.TypeOfCase;
using FinalProject.Core.Application.ViewModel.User;
using FinalProject.Core.Domain.Entities;

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
            
            CreateMap<TipoCaso, SaveTypeOfCaseViewModel>()
                .ReverseMap(); 
            
            CreateMap<TipoCaso, TypeOfCaseViewModel>()
                .ReverseMap();
            
            CreateMap<EstadoCaso, SaveStatusOfCaseViewModel>()
                .ReverseMap(); 
            
            CreateMap<EstadoCaso, StatusOfCaseViewModel>()
                .ReverseMap();
                
        }
    }
}
