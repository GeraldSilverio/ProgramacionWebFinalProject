using Microsoft.AspNetCore.Identity;

namespace FinalProject.Infraestructure.Identity.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string Cedula {  get; set; }
        public string Nombre {  get; set; }
        public string Apellido {  get; set; }
        public string Direccion {  get; set; }
        public string EstadoCivil {  get; set; }
    }
}
