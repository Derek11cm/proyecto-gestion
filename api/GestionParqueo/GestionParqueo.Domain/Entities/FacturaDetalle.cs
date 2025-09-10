using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionParqueo.Domain.Entities
{
    public class FacturaDetalle
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal TotalLinea { get; set; }

        // Clave foránea
        public int FacturaId { get; set; }

        // Propiedad de navegación
        public Factura Factura { get; set; }
    }
}