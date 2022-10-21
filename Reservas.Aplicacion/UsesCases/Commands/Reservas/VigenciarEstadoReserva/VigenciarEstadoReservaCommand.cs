using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Commands.Reservas.VigenciarEstadoReserva {
  public class VigenciarEstadoReservaCommand : IRequest<Guid> {
    public Guid Id { get; set; }

    public VigenciarEstadoReservaCommand(Guid id) {
      this.Id = id;
    }
  }
}
