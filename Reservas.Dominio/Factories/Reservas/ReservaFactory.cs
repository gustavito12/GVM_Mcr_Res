using Reservas.Dominio.Events.Reservas;
using Reservas.Dominio.Models.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Dominio.Factories.Reservas {
  public class ReservaFactory : IReservaFactory {
    public Reserva Create(string nroReserva) {
      //var obj = new Reserva(nroReserva);
      //var domainEvent = new ReservaCreadaEvent(obj.Id, nroReserva, DateTime.Now);

      //obj.AddDomainEvent(domainEvent);

      //return obj;
      return new Reserva(nroReserva);
    }
  }
}
