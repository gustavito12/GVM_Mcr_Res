using MediatR;
using Microsoft.EntityFrameworkCore;
using Reservas.Aplicacion.Dtos.Pagos;
using Reservas.Aplicacion.Dtos.Reservas;
using Reservas.Aplicacion.UsesCases.Queries.Reservas.BuscarReservas;
using Reservas.Dominio.Models.Pagos;
using Reservas.Dominio.Models.Vuelos;
using Reservas.Infraestructura.EntityFramework.Contexts;
using Reservas.Infraestructura.EntityFramework.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Infraestructura.EntityFramework.UseCases.Queries.Reservas {
  public class BuscarReservasHandler :
       IRequestHandler<BuscarReservasQuery, ICollection<ReservaDto>> {
    private readonly DbSet<PagoReadModel> _pagos;
    private readonly DbSet<FacturaReadModel> _factura;
    private readonly DbSet<ReservaReadModel> _reserva;
    private readonly DbSet<VueloReadModel> _vuelo;
    private readonly DbSet<ClienteReadModel> _cliente;

    public BuscarReservasHandler(ReadDbContext context) {
      _pagos = context.Pago;
      _factura = context.Factura;
      _reserva = context.Reserva;
      _vuelo = context.Vuelo;
      _cliente = context.Cliente;
    }
    public async Task<ICollection<ReservaDto>> Handle(BuscarReservasQuery request, CancellationToken cancellationToken) {
      var ReservaList = await _reserva
                      .AsNoTracking()
                      .Join(_vuelo, p => p.Vuelo.Id, c => c.Id, (p, c) => new { p, c })
                      .Join(_cliente, d => d.p.Cliente.Id, e => e.Id, (d, e) => new { d, e })
                      .Take(100)//.Take(request.Cantidad)
                      .Where(e => e.d.p.EstadoReserva != "I" && e.d.p.EstadoReserva != "F" && e.d.p.EstadoReserva != "C")
                      .ToListAsync();

      var result = new List<ReservaDto>();

      foreach (var objReserva in ReservaList) {
        ReservaDto objReservaDto = new();
        objReservaDto.Id = objReserva.d.p.Id;
        objReservaDto.CodReserva = objReserva.d.p.CodReserva;
        objReservaDto.EstadoReserva = objReserva.d.p.EstadoReserva;
        objReservaDto.Monto = objReserva.d.p.Monto;
        objReservaDto.Deuda = objReserva.d.p.Deuda;
        objReservaDto.Fecha = objReserva.d.p.Fecha;
        objReservaDto.TipoReserva = objReserva.d.p.TipoReserva;
        objReservaDto.ClienteId = objReserva.d.c.Id;
        objReservaDto.VueloId = objReserva.e.Id;
        result.Add(objReservaDto);

      }

      return result;
      // throw new NotImplementedException();
    }
  }
}
