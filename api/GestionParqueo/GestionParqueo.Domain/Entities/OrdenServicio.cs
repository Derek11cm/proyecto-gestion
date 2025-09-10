using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestionParqueo.Domain.Entities
{
    public enum EstadoOrdenServicio
    {
        Pendiente,
        EnProceso,
        Lista,
        Cobrada,
        Cancelada
    }

    public class OrdenServicio
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaProgramada { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public decimal Total { get; set; }
        public EstadoOrdenServicio Estado { get; set; }

        // Claves foráneas
        public int ClienteId { get; set; }
        public int VehiculoId { get; set; }

        // Propiedades de navegación
        public Cliente Cliente { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public ICollection<OrdenServicioDetalle> Detalles { get; set; }

        public OrdenServicio()
        {
            Detalles = new HashSet<OrdenServicioDetalle>();
        }
    }
}