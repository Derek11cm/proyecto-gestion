using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionParqueo.Domain.Entities
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }

        // Propiedad para la clave foránea (Foreign Key)
        public int ClienteId { get; set; }

        // Propiedad de navegación a la entidad "padre"
        public Cliente Cliente { get; set; }

        public ICollection<OrdenServicio> OrdenesServicio { get; set; }
        public Vehiculo()
        {
            OrdenesServicio = new HashSet<OrdenServicio>();
        }
    }
}
