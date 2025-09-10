using MediatR;
using GestionParqueo.Application.DTOs;
using System.Collections.Generic;

namespace GestionParqueo.Application.Features.Parqueos.Queries
{
    public class GetAllParqueosQuery : IRequest<IEnumerable<ParqueoDto>>
    {
    }
}