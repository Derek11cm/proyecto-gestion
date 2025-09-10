using MediatR;

namespace GestionParqueo.Application.Features.Parqueos.Commands
{
    public class AssignParqueoCommand : IRequest<int> // Devuelve el ID de la nueva asignación
    {
        public int ClienteId { get; set; }
        public int ParqueoId { get; set; }
        public decimal TarifaCobrada { get; set; }
    }
}