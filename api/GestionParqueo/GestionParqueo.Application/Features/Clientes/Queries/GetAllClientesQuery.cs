
using MediatR;
using GestionParqueo.Application.DTOs;
using System.Collections.Generic;

namespace GestionParqueo.Application.Features.Clientes.Queries
{
    public class GetAllClientesQuery : IRequest<IEnumerable<ClienteDto>>
    {
    }
}