using MediatR;
using Reservas.Aplicacion.Dtos.Clientes;
using Reservas.Aplicacion.Dtos.Vuelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Queries.Reservas.Clientes {
  public class BuscarClientesQuery : IRequest<ICollection<ClienteDto>> {
    //public int Cantidad { get; set; }
  }
}
