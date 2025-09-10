using MediatR;
using Microsoft.EntityFrameworkCore;
using GestionParqueo.Application.Interfaces;
using GestionParqueo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace GestionParqueo.Application.Features.Parqueos.Commands
{
    public class AssignParqueoCommandHandler : IRequestHandler<AssignParqueoCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public AssignParqueoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AssignParqueoCommand request, CancellationToken cancellationToken)
        {
            // 1. Validar que el parqueo existe y está disponible
            var parqueo = await _context.Parqueos.FirstOrDefaultAsync(p => p.Id == request.ParqueoId, cancellationToken);
            if (parqueo == null || parqueo.Estado != EstadoParqueo.Disponible)
            {
                throw new Exception("El parqueo no existe o no está disponible.");
            }

            // 2. Validar que el cliente existe
            var cliente = await _context.Clientes.AnyAsync(c => c.Id == request.ClienteId, cancellationToken);
            if (!cliente)
            {
                throw new Exception("El cliente no existe.");
            }

            // 3. Cambiar el estado del parqueo a Ocupado
            parqueo.Estado = EstadoParqueo.Ocupado;

            // 4. Crear el registro de la asignación
            var nuevaAsignacion = new AsignacionParqueo
            {
                ClienteId = request.ClienteId,
                ParqueoId = request.ParqueoId,
                TarifaCobrada = request.TarifaCobrada,
                FechaAsignacion = DateTime.UtcNow,
                Activa = true
            };

            _context.AsignacionesParqueo.Add(nuevaAsignacion);

            // 5. Guardar todos los cambios en una sola transacción
            await _context.SaveChangesAsync(cancellationToken);

            return nuevaAsignacion.Id;
        }
    }
}