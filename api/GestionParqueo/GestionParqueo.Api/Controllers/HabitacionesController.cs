using GestionParqueo.Application.Features.Habitaciones.Commands;
using GestionParqueo.Application.Features.Habitaciones.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GestionParqueo.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HabitacionesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HabitacionesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllHabitacionesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHabitacionCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAll), new { id }, null);
        }

        [HttpPost("reservar")]
        public async Task<IActionResult> Reserve([FromBody] ReserveHabitacionCommand command)
        {
            try
            {
                var reservacionId = await _mediator.Send(command);
                return Ok(new { ReservacionId = reservacionId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}