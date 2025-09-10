using MediatR;
using GestionParqueo.Application.Interfaces;
using GestionParqueo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace GestionParqueo.Application.Features.Habitaciones.Commands
{
    public class CreateHabitacionCommandHandler : IRequestHandler<CreateHabitacionCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateHabitacionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateHabitacionCommand request, CancellationToken cancellationToken)
        {
            var nuevaHabitacion = new Habitacion
            {
                Numero = request.Numero,
                Descripcion = request.Descripcion,
                TarifaMensual = request.TarifaMensual,
                Estado = EstadoHabitacion.Disponible
            };

            _context.Habitaciones.Add(nuevaHabitacion);
            await _context.SaveChangesAsync(cancellationToken);
            return nuevaHabitacion.Id;
        }
    }
}