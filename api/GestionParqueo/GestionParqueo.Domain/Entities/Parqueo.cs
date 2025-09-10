using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionParqueo.Domain.Entities
{
    public enum EstadoParqueo
    {
        Disponible,
        Ocupado,
        Mantenimiento
    }

    public class Parqueo
    {
        public int Id { get; set; }
        public string Codigo { get; set; } // Ej: "A-01", "S1-15"
        public string Descripcion { get; set; }
        public EstadoParqueo Estado { get; set; }

        // Propiedad de navegación
        public ICollection<AsignacionParqueo> Asignaciones { get; set; }

        public Parqueo()
        {
            Asignaciones = new HashSet<AsignacionParqueo>();
        }
    }
}