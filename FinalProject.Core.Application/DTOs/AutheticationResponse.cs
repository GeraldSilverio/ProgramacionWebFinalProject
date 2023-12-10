namespace FinalProject.Core.Application.DTOs
{
    public class AutheticationResponse
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contraseña { get; set; }
        public string ConfirmarContraseña { get; set; }
        public string NombreUsuario { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public List<string> Roles { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string EstadoCivil { get; set; }
        public string? Error { get; set; }
        public bool HasError { get; set; }
    }
}
