using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionParqueo.Domain.Entities
{
    public class ReservacionHabitacion
    {
        public int Id { get; set; }
        public DateTime FechaCheckIn { get; set; }
        public DateTime? FechaCheckOut { get; set; } // Nullable si sigue activa
        public decimal TarifaCobrada { get; set; }
        public bool Activa { get; set; }

        // Claves foráneas
        public int ClienteId { get; set; }
        public int HabitacionId { get; set; }

        // Propiedades de navegación
        public Cliente Cliente { get; set; }
        public Habitacion Habitacion { get; set; }
    }
}