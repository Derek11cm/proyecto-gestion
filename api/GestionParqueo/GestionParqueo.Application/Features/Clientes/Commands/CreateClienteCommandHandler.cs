// In GestionParqueo.Application/Features/Clientes/Commands/CreateClienteCommandHandler.cs
using MediatR;
using GestionParqueo.Application.Interfaces;
using GestionParqueo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace GestionParqueo.Application.Features.Clientes.Commands
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateClienteCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            // 1. Create a new Cliente entity from the Domain project
            var nuevoCliente = new Cliente
            {
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                DocumentoIdentidad = request.DocumentoIdentidad,
                Telefono = request.Telefono,
                Email = request.Email,
                Activo = true, // Set default values
                FechaRegistro = DateTime.UtcNow
            };

            // 2. Add the new entity to the context
            _context.Clientes.Add(nuevoCliente);

            // 3. Save the changes to the database
            await _context.SaveChangesAsync(cancellationToken);

            // 4. Return the ID of the newly created entity
            return nuevoCliente.Id;
        }
    }
}