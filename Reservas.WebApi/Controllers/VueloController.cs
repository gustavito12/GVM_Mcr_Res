using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservas.Aplicacion.UsesCases.Commands.Reservas.CrearReserva;
using System.Threading.Tasks;
using System;
using Reservas.Aplicacion.UsesCases.Commands.Vuelos.CrearVuelo;
using Reservas.Aplicacion.UsesCases.Queries.Reservas.BuscarReservas;
using Reservas.Aplicacion.UsesCases.Queries.Reservas.Vuelos;
using Reservas.Aplicacion.UsesCases.Queries.Reservas.Clientes;

namespace Reservas.WebApi.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class VueloController : ControllerBase {
    private readonly IMediator _mediator;

    public VueloController(IMediator mediator) {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CrearVueloCommand command) {
      Guid id = await _mediator.Send(command);

      if (id == Guid.Empty)
        return BadRequest();

      return Ok(id);
    }

    //[Route("BuscarVuelos")]
    //[HttpPost]
    //public async Task<IActionResult> Search([FromBody] BuscarVuelosQuery query)
    //{
    //    var facturas = await _mediator.Send(query);

    //    if (facturas == null)
    //        return BadRequest();

    //    return Ok(facturas);
    //}

    [Route("BuscarVuelos")]
    [HttpGet]
    public async Task<IActionResult> ObtenerReservaPorId([FromRoute] BuscarVuelosQuery command) {
      var vuelos = await _mediator.Send(command);

      if (vuelos == null)
        return NotFound();

      return Ok(vuelos);
    }
  }
}
