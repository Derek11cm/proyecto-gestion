using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionParqueo.Domain.Entities;

namespace GestionParqueo.Application.DTOs
{
    public class ParqueoDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}