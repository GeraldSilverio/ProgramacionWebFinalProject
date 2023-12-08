using FinalProject.Core.Application.ViewModel.StatusOfCase;
using FinalProject.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Application.Interfaces.Services
{
    public interface IStatusOfCaseServices:IGenericService<EstadoCaso,SaveStatusOfCaseViewModel,StatusOfCaseViewModel>
    {
    }
}
