using MediatR;
using Reservas.Aplicacion.Dtos.Reservas;
using Reservas.Aplicacion.Dtos.Vuelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Queries.Reservas.Vuelos {
  public class BuscarVuelosQuery : IRequest<ICollection<VueloDto>> {
    //public int Cantidad { get; set; }
  }
}
