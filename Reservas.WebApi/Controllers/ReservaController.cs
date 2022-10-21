using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reservas.Aplicacion.Dtos.Pagos;
using Reservas.Aplicacion.Dtos.Reservas;
using Reservas.Aplicacion.UsesCases.Commands.Pagos.CrearFactura;
using Reservas.Aplicacion.UsesCases.Commands.Pagos.CrearPago;
using Reservas.Aplicacion.UsesCases.Commands.Productos;
using Reservas.Aplicacion.UsesCases.Commands.Reservas.CancelarReserva;
using Reservas.Aplicacion.UsesCases.Commands.Reservas.CrearReserva;
using Reservas.Aplicacion.UsesCases.Commands.Reservas.VigenciarEstadoReserva;
using Reservas.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturaPorId;
using Reservas.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturasReserva;
using Reservas.Aplicacion.UsesCases.Queries.Pagos.BuscarPagosReserva;
using Reservas.Aplicacion.UsesCases.Queries.Reservas.BuscarReservas;
using Reservas.Aplicacion.UsesCases.Queries.Reservas.Clientes;
using Reservas.Aplicacion.UsesCases.Queries.Reservas.ObtenerReservaId;
using System;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Reservas.WebApi.Controllers {
  [ApiController]
  [Route("/api/[controller]")]
  public class ReservaController : ControllerBase {
    private readonly IMediator _mediator;

    public ReservaController(IMediator mediator) {
      _mediator = mediator;
    }
    [Route("Factura")]
    [HttpPost]
    public async Task<IActionResult> CreatePago([FromBody] CrearFacturaCommand command) {
      Guid id = await _mediator.Send(command);

      if (id == Guid.Empty)
        return BadRequest();

      return Ok(id);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CrearReservaCommand command) {
      Guid id = await _mediator.Send(command);

      if (id == Guid.Empty)
        return BadRequest();

      return Ok(id);
    }
    [Route("Pago")]
    [HttpPost]
    public async Task<IActionResult> CreatePago([FromBody] CrearPagoCommand command) {
      Guid id = await _mediator.Send(command);

      if (id == Guid.Empty)
        return BadRequest();

      return Ok(id);
    }
    [Route("CancelarReserva")]
    [HttpPost]
    public async Task<IActionResult> CreateFactura([FromBody] CancelarReservaCommand command) {
      Guid id = await _mediator.Send(command);

      if (id == Guid.Empty)
        return BadRequest();

      return Ok(id);
    }

    [Route("MarcaCheckin")]
    [HttpPost]
    public async Task<IActionResult> CreateFactura([FromBody] VigenciarEstadoReservaCommand command) {
      Guid id = await _mediator.Send(command);

      if (id == Guid.Empty)
        return BadRequest();

      return Ok(id);
    }

    [Route("{id:guid}")]
    [HttpGet]
    public async Task<IActionResult> ObtenerReservaPorId([FromRoute] ObtenerReservaIdQuery command) {
      ReservaDto result = await _mediator.Send(command);

      if (result == null)
        return NotFound();

      return Ok(result);
    }
    [Route("BuscarPagos")]
    [HttpPost]
    public async Task<IActionResult> Search([FromBody] BuscarPagosReservaQuery query) {
      var pedidos = await _mediator.Send(query);

      if (pedidos == null)
        return BadRequest();

      return Ok(pedidos);
    }
    [Route("Factura/{id:guid}")]
    [HttpGet]
    public async Task<IActionResult> ObtenerFacturaPorId([FromRoute] BuscarFacturaPorIdQuery command) {
      FacturaDto result = await _mediator.Send(command);

      if (result == null)
        return NotFound();

      return Ok(result);
    }

    [Route("BuscarFacturaReserva")]
    [HttpPost]
    public async Task<IActionResult> Search([FromBody] BuscarFacturasReservaQuery query) {
      var facturas = await _mediator.Send(query);

      if (facturas == null)
        return BadRequest();

      return Ok(facturas);
    }

    //[Route("BuscarReservas")]
    //[Route("BuscarReservas")]
    //[HttpPost]
    //public async Task<IActionResult> Search([FromBody] BuscarReservasQuery query)
    //{
    //    var facturas = await _mediator.Send(query);

    //    if (facturas == null)
    //        return BadRequest();

    //    return Ok(facturas);
    //}


    [Route("BuscarReservas")]
    [HttpGet]
    public async Task<IActionResult> ObtenerReservaPorId([FromRoute] BuscarReservasQuery command) {
      var reservas = await _mediator.Send(command);

      if (reservas == null)
        return NotFound();

      return Ok(reservas);
    }

    // [HttpPost]
    //public async Task<IActionResult> Create([FromBody] CrearProductoCommand command)
    //{
    //    Guid id = (Guid)await _mediator.Send(command);

    //    if (id == Guid.Empty)
    //        return BadRequest();

    //    return Ok(id);
    //}
  }
}
