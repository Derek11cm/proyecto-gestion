using MediatR;
using GestionParqueo.Application.Interfaces;
using GestionParqueo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace GestionParqueo.Application.Features.Parqueos.Commands
{
    public class CreateParqueoCommandHandler : IRequestHandler<CreateParqueoCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateParqueoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateParqueoCommand request, CancellationToken cancellationToken)
        {
            var nuevoParqueo = new Parqueo
            {
                Codigo = request.Codigo,
                Descripcion = request.Descripcion,
                Estado = EstadoParqueo.Disponible // Por defecto, un nuevo parqueo está disponible
            };

            _context.Parqueos.Add(nuevoParqueo);
            await _context.SaveChangesAsync(cancellationToken);
            return nuevoParqueo.Id;
        }
    }
}