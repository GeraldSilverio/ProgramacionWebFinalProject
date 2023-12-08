namespace FinalProject.Core.Application.ViewModel.Case
{
    public class SaveCaseViewModel
    {
        public int Id { get; set; }
        public DateTime FechaCaso { get; set; } = DateTime.Now;
        public string IdCliente { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Descripcion { get; set; }
        public string IdAbogado { get; set; }
        public int IdTipoCaso { get; set; }
        public int IdEstadoCaso { get; set; }




    }
}
