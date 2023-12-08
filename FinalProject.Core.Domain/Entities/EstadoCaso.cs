using FinalProject.Core.Domain.Commons;

namespace FinalProject.Core.Domain.Entities
{
    public class EstadoCaso:BaseEntity
    {
        public string Nombre { get; set; }

        public ICollection<Caso> Casos { get; set; }
    }
}
