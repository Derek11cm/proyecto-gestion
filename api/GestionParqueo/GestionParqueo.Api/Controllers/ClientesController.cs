using MediatR;
using Microsoft.AspNetCore.Mvc;
using GestionParqueo.Application.Features.Clientes.Queries;
using System.Threading.Tasks;
using GestionParqueo.Application.Features.Clientes.Commands;
using Microsoft.AspNetCore.Authorization;

namespace GestionParqueo.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        // Constructor para la inyección de dependencias de MediatR
        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //==============================================================
        // MÉTODO PARA OBTENER TODOS LOS CLIENTES (LEER)
        //==============================================================
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clientes = await _mediator.Send(new GetAllClientesQuery());
            return Ok(clientes);
        }

        //==============================================================
        // MÉTODO PARA CREAR UN NUEVO CLIENTE (ESCRIBIR)
        //==============================================================
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateClienteCommand command)
        {
            var nuevoClienteId = await _mediator.Send(command);

            // Retorna una respuesta 201 Created con el ID del nuevo cliente
            return CreatedAtAction(nameof(Get), new { id = nuevoClienteId }, null);
        }
    }
}