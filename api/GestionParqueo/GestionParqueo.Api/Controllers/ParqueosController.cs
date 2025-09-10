using GestionParqueo.Application.Features.Parqueos.Commands;
using GestionParqueo.Application.Features.Parqueos.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestionParqueo.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ParqueosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParqueosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllParqueosQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateParqueoCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAll), new { id }, null);
        }

        [HttpPost("asignar")]
        public async Task<IActionResult> Assign([FromBody] AssignParqueoCommand command)
        {
            try
            {
                var asignacionId = await _mediator.Send(command);
                return Ok(new { AsignacionId = asignacionId });
            }
            catch (Exception ex)
            {
                // En una app real, manejarías diferentes tipos de excepciones
                return BadRequest(ex.Message);
            }
        }
    }
}