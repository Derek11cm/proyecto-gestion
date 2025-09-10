using MediatR;

namespace GestionParqueo.Application.Features.Clientes.Commands
{
    public class CreateClienteCommand : IRequest<int>
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}