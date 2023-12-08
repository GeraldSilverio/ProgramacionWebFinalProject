namespace FinalProject.Core.Application.DTOs
{
    public class RegisterRequest
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Phone { get; set; }
        public int SelectRole { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string EstadoCivil { get; set; }
    }
}
