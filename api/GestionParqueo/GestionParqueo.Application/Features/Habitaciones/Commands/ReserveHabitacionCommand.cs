using MediatR;

namespace GestionParqueo.Application.Features.Habitaciones.Commands
{
    public class ReserveHabitacionCommand : IRequest<int>
    {
        public int ClienteId { get; set; }
        public int HabitacionId { get; set; }
        public decimal TarifaCobrada { get; set; }
    }
}