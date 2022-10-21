using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Dominio.Events {
  public record VueloCreadoEvent : DomainEvent {

    public Guid Id { get; set; }
    public int Cantidad { get; set; }
    public string Detalle { get; set; }
    public decimal PrecioPasaje { get; set; }

    public VueloCreadoEvent(Guid id, int cantidad, string detalle, decimal precioPasaje) : base(DateTime.Now) {
      Id = id;
      Detalle = detalle;
      Cantidad = cantidad;
      PrecioPasaje = precioPasaje;
    }
  }
}
