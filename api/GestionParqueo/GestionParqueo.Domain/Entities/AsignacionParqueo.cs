using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionParqueo.Domain.Entities
{
    public class AsignacionParqueo
    {
        public int Id { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime? FechaRevocacion { get; set; } // Nullable si sigue activa
        public decimal TarifaCobrada { get; set; }
        public bool Activa { get; set; }

        // Claves foráneas para la relación
        public int ClienteId { get; set; }
        public int ParqueoId { get; set; }

        // Propiedades de navegación
        public Cliente Cliente { get; set; }
        public Parqueo Parqueo { get; set; }
    }
}