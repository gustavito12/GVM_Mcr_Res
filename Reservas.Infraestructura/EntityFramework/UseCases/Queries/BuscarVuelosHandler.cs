using MediatR;
using Microsoft.EntityFrameworkCore;
using Reservas.Aplicacion.Dtos.Reservas;
using Reservas.Aplicacion.Dtos.Vuelos;
using Reservas.Aplicacion.UsesCases.Queries.Reservas.BuscarReservas;
using Reservas.Aplicacion.UsesCases.Queries.Reservas.Vuelos;
using Reservas.Infraestructura.EntityFramework.Contexts;
using Reservas.Infraestructura.EntityFramework.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Infraestructura.EntityFramework.UseCases.Queries {
  public class BuscarVuelosHandler :
       IRequestHandler<BuscarVuelosQuery, ICollection<VueloDto>> {

    private readonly DbSet<VueloReadModel> _vuelo;

    public BuscarVuelosHandler(ReadDbContext context) {
      _vuelo = context.Vuelo;
    }
    public async Task<ICollection<VueloDto>> Handle(BuscarVuelosQuery request, CancellationToken cancellationToken) {
      var VueloList = await _vuelo
                      .Take(100)//.Take(request.Cantidad)
                      .ToListAsync();

      var result = new List<VueloDto>();

      foreach (var objVuelo in VueloList) {
        VueloDto objVueloDto = new();
        objVueloDto.Id = objVuelo.Id;
        objVueloDto.Detalle = objVuelo.Detalle;
        objVueloDto.Cantidad = objVuelo.Cantidad;
        objVueloDto.PrecioPasaje = objVuelo.PrecioPasaje;

        result.Add(objVueloDto);

      }

      return result;
    }
  }
}
