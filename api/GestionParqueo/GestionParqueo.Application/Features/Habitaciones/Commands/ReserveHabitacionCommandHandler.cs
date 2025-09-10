using MediatR;
using Microsoft.EntityFrameworkCore;
using GestionParqueo.Application.Interfaces;
using GestionParqueo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace GestionParqueo.Application.Features.Habitaciones.Commands
{
    public class ReserveHabitacionCommandHandler : IRequestHandler<ReserveHabitacionCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public ReserveHabitacionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(ReserveHabitacionCommand request, CancellationToken cancellationToken)
        {
            // 1. Validar que la habitación existe y está disponible
            var habitacion = await _context.Habitaciones.FirstOrDefaultAsync(h => h.Id == request.HabitacionId, cancellationToken);
            if (habitacion == null || habitacion.Estado != EstadoHabitacion.Disponible)
            {
                throw new Exception("La habitación no existe o no está disponible.");
            }

            // 2. Validar que el cliente existe
            var cliente = await _context.Clientes.AnyAsync(c => c.Id == request.ClienteId, cancellationToken);
            if (!cliente)
            {
                throw new Exception("El cliente no existe.");
            }

            // 3. Cambiar el estado de la habitación a Ocupada
            habitacion.Estado = EstadoHabitacion.Ocupada;

            // 4. Crear el registro de la reservación
            var nuevaReservacion = new ReservacionHabitacion
            {
                ClienteId = request.ClienteId,
                HabitacionId = request.HabitacionId,
                TarifaCobrada = request.TarifaCobrada,
                FechaCheckIn = DateTime.UtcNow,
                Activa = true
            };

            _context.ReservacionesHabitacion.Add(nuevaReservacion);

            // 5. Guardar todos los cambios
            await _context.SaveChangesAsync(cancellationToken);

            return nuevaReservacion.Id;
        }
    }
}