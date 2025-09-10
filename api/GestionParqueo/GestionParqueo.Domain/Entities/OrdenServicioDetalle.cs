using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionParqueo.Domain.Entities
{
    public class OrdenServicioDetalle
    {
        public int Id { get; set; }

        // Claves foráneas
        public int OrdenServicioId { get; set; }
        public int ServicioId { get; set; }

        // Precio al momento de la venta
        public decimal PrecioCobrado { get; set; }

        // Propiedades de navegación
        public OrdenServicio OrdenServicio { get; set; }
        public Servicio Servicio { get; set; }
    }
}