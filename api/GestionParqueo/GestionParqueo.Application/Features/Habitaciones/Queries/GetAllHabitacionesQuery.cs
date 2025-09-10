using MediatR;
using GestionParqueo.Application.DTOs;
using System.Collections.Generic;

namespace GestionParqueo.Application.Features.Habitaciones.Queries
{
    public class GetAllHabitacionesQuery : IRequest<IEnumerable<HabitacionDto>>
    {
    }
}