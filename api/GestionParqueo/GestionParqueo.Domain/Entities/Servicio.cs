using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionParqueo.Domain.Entities
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; } // Ej: "Lavado Básico", "Pulido de 3 Pasos"
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; } // Para poder desactivar servicios sin borrarlos
    }
}
