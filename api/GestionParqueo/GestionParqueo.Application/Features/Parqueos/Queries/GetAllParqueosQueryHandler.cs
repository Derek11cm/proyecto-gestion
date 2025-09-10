using MediatR;
using Microsoft.EntityFrameworkCore;
using GestionParqueo.Application.DTOs;
using GestionParqueo.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestionParqueo.Application.Features.Parqueos.Queries
{
    public class GetAllParqueosQueryHandler : IRequestHandler<GetAllParqueosQuery, IEnumerable<ParqueoDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllParqueosQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ParqueoDto>> Handle(GetAllParqueosQuery request, CancellationToken cancellationToken)
        {
            return await _context.Parqueos
                .Select(p => new ParqueoDto
                {
                    Id = p.Id,
                    Codigo = p.Codigo,
                    Descripcion = p.Descripcion,
                    Estado = p.Estado.ToString() // Convertimos el enum a string
                })
                .ToListAsync(cancellationToken);
        }
    }
}