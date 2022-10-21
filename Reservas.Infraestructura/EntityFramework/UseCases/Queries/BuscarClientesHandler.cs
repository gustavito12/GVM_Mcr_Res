using MediatR;
using Microsoft.EntityFrameworkCore;
using Reservas.Aplicacion.Dtos.Clientes;
using Reservas.Aplicacion.Dtos.Vuelos;
using Reservas.Aplicacion.UsesCases.Queries.Reservas.Clientes;
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
  public class BuscarClientesHandler :
       IRequestHandler<BuscarClientesQuery, ICollection<ClienteDto>> {
    private readonly DbSet<ClienteReadModel> _cliente;

    public BuscarClientesHandler(ReadDbContext context) {
      _cliente = context.Cliente;
    }
    public async Task<ICollection<ClienteDto>> Handle(BuscarClientesQuery request, CancellationToken cancellationToken) {
      var ClienteList = await _cliente
                      .Take(100)//.Take(request.Cantidad)
                      .ToListAsync();

      var result = new List<ClienteDto>();

      foreach (var objCliente in ClienteList) {
        ClienteDto objClienteDto = new();
        objClienteDto.Id = objCliente.Id;
        objClienteDto.NombreCompleto = objCliente.NombreCompleto;

        result.Add(objClienteDto);

      }

      return result;
    }
  }
}
