using MediatR;

namespace GestionParqueo.Application.Features.Habitaciones.Commands
{
    public class CreateHabitacionCommand : IRequest<int>
    {
        public string Numero { get; set; }
        public string Descripcion { get; set; }
        public decimal TarifaMensual { get; set; }
    }
}