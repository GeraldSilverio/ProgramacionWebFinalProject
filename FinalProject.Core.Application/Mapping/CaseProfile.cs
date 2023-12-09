

using AutoMapper;
using FinalProject.Core.Application.ViewModel.Case;

namespace FinalProject.Core.Application.Mapping
{
    public class CaseProfile : Profile
    {
        public CaseProfile()
        {
            CreateMap<SaveCaseViewModel, CaseViewModel>()
                .ReverseMap();
        }
    }
}
