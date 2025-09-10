using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionParqueo.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }

        // Propiedades de navegación para las relaciones
        public ICollection<Vehiculo> Vehiculos { get; set; }
        public ICollection<Factura> Facturas { get; set; }
        public ICollection<OrdenServicio> OrdenesServicio { get; set; }

        public Cliente()
        {
            Vehiculos = new HashSet<Vehiculo>();
            Facturas = new HashSet<Factura>();
            OrdenesServicio = new HashSet<OrdenServicio>(); // inicializarla también
        }
    }
}