namespace FinalProject.Core.Application.ViewModel.Case
{
    public class CaseViewModel
    {
        public int Id { get; set; }
        public DateTime FechaCaso { get; set; }
        public string IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Descripcion { get; set; }
        public string IdAbogado { get; set; }
        public string NombreAbogado { get; set; }
        public int IdTipoCaso { get; set; }
        public string NombreTipoCaso { get; set; }
        public int IdEstadoCaso { get; set; }
        public string NombreEstadoCaso { get; set; }
    }
}
