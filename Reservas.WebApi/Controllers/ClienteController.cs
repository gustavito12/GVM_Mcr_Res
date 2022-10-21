using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reservas.Aplicacion.Dtos.Clientes;
using Reservas.Aplicacion.Dtos.Reservas;
using Reservas.Aplicacion.UsesCases.Queries.Reservas.Clientes;
using Reservas.Aplicacion.UsesCases.Queries.Reservas.ObtenerReservaId;
using Reservas.Aplicacion.UsesCases.Queries.Reservas.Vuelos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Reservas.WebApi.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class ClienteController : ControllerBase {

    private readonly IMediator _mediator;

    public ClienteController(IMediator mediator) {
      _mediator = mediator;
    }

    //[Route("BuscarClientes")]
    //[HttpPost]
    //public async Task<IActionResult> Search([FromBody] BuscarClientesQuery query)
    //{
    //    var clientes = await _mediator.Send(query);

    //    if (clientes == null)
    //        return BadRequest();

    //    return Ok(clientes);
    //}

    [Route("BuscarClientes")]
    [HttpGet]
    public async Task<IActionResult> ObtenerReservaPorId([FromRoute] BuscarClientesQuery command) {
      var clientes = await _mediator.Send(command);

      if (clientes == null)
        return NotFound();

      return Ok(clientes.ToList());
    }
  }
}
