using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionParqueo.Domain.Entities
{
    public enum MetodoPago
    {
        Efectivo,
        Transferencia,
        Tarjeta
    }

    public class Pago
    {
        public int Id { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public MetodoPago Metodo { get; set; }
        public string Referencia { get; set; } // Ej: ID de transferencia, # de cheque

        // Clave foránea
        public int FacturaId { get; set; }

        // Propiedad de navegación
        public Factura Factura { get; set; }
    }
}