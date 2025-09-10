using MediatR;
using Microsoft.EntityFrameworkCore;
using GestionParqueo.Application.DTOs;
using GestionParqueo.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestionParqueo.Application.Features.Habitaciones.Queries
{
    public class GetAllHabitacionesQueryHandler : IRequestHandler<GetAllHabitacionesQuery, IEnumerable<HabitacionDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllHabitacionesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HabitacionDto>> Handle(GetAllHabitacionesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Habitaciones
                .Select(h => new HabitacionDto
                {
                    Id = h.Id,
                    Numero = h.Numero,
                    Descripcion = h.Descripcion,
                    TarifaMensual = h.TarifaMensual,
                    Estado = h.Estado.ToString()
                })
                .ToListAsync(cancellationToken);
        }
    }
}