using MediatR;

namespace GestionParqueo.Application.Features.Parqueos.Commands
{
    public class CreateParqueoCommand : IRequest<int>
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}