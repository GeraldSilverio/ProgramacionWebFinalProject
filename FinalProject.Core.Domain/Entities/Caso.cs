using FinalProject.Core.Domain.Commons;

namespace FinalProject.Core.Domain.Entities
{
    public class Caso:BaseEntity
    {
        public DateTime FechaCaso { get; set; }
        public string IdCliente {  get; set; }
        public string Latitud {  get; set; }
        public string Longitud {  get; set; }
        public string Descripcion { get; set; }
        public string IdAbogado { get; set; }

        #region NavegationProperties
        public int IdTipoCaso { get; set; }
        public TipoCaso TipoCaso { get; set; }
        public int IdEstadoCaso {  get; set; }
        public EstadoCaso EstadoCaso { get; set; }
        #endregion
    }
}
