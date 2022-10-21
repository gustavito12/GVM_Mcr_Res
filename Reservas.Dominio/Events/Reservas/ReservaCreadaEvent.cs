using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Dominio.Events.Reservas {
  public record ReservaCreadaEvent : DomainEvent {
    public Guid ReservaId { get; set; }
    public Guid VueloId { get; set; }
    //public string NroReserva { get; set; }
    //public ReservaCreadaEvent(Guid reservaId, Guid vueloId) : base(DateTime.Now)
    //{
    //    ReservaId = reservaId;
    //    VueloId = vueloId;
    //}
    //public ReservaCreadaEvent(Guid reservaId, Guid vueloId , DateTime occuredOn) : base(occuredOn)
    public ReservaCreadaEvent(Guid reservaId, Guid vueloId, DateTime occuredOn) : base(occuredOn) {
      ReservaId = reservaId;
      VueloId = vueloId;
    }

    //public ReservaCreadaEvent(Guid reservaId, Guid vueloId) : base(DateTime.Now)
    //{
    //    ReservaId = reservaId;
    //    VueloId = vueloId;
    //}
  }
}
