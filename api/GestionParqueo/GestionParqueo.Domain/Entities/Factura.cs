using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionParqueo.Domain.Entities
{
    public enum EstadoFactura
    {
        Pendiente,
        Pagada,
        Anulada
    }

    public class Factura
    {
        public int Id { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Total { get; set; }
        public EstadoFactura Estado { get; set; }

        // Clave foránea
        public int ClienteId { get; set; }

        // Propiedades de navegación
        public Cliente Cliente { get; set; }
        public ICollection<FacturaDetalle> Detalles { get; set; }
        public ICollection<Pago> Pagos { get; set; }

        public Factura()
        {
            Detalles = new HashSet<FacturaDetalle>();
            Pagos = new HashSet<Pago>();
        }
    }
}