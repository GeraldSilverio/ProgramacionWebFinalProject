using System.ComponentModel.DataAnnotations;

namespace FinalProject.Core.Application.ViewModel.Login
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Debe ingresar un nombre de usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Debe ingresar una contraseña con caracteres especiales, numeros y al menos una mayúscula")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}
