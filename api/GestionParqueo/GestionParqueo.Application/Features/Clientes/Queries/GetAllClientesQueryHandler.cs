// En GestionParqueo.Application/Features/Clientes/Queries/GetAllClientesQueryHandler.cs
using GestionParqueo.Application.DTOs;
using GestionParqueo.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestionParqueo.Application.Features.Clientes.Queries
{
    public class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, IEnumerable<ClienteDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllClientesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClienteDto>> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
        {
            var clientes = await _context.Clientes
                .Select(c => new ClienteDto
                {
                    Id = c.Id,
                    NombreCompleto = c.Nombres + " " + c.Apellidos,
                    Email = c.Email,
                    Activo = c.Activo
                })
                .ToListAsync(cancellationToken);

            return clientes;
        }
    }
}