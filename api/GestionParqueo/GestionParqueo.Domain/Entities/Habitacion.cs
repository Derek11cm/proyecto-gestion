using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionParqueo.Domain.Entities
{
    public enum EstadoHabitacion
    {
        Disponible,
        Ocupada,
        Mantenimiento,
        Reservada
    }

    public class Habitacion
    {
        public int Id { get; set; }
        public string Numero { get; set; } // Ej: "101", "20B"
        public string Descripcion { get; set; }
        public decimal TarifaMensual { get; set; }
        public EstadoHabitacion Estado { get; set; }

        // Propiedad de navegación
        public ICollection<ReservacionHabitacion> Reservaciones { get; set; }

        public Habitacion()
        {
            Reservaciones = new HashSet<ReservacionHabitacion>();
        }
    }
}