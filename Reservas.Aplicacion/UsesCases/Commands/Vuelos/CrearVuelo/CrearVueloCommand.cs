using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Commands.Vuelos.CrearVuelo {
  [ExcludeFromCodeCoverage]
  public class CrearVueloCommand : IRequest<Guid> {
    public Guid Id { get; set; }
    public int Cantidad { get; set; }
    public string Detalle { get; set; }
    public decimal PrecioPasaje { get; set; }

    public CrearVueloCommand(Guid id, int cantidad, string detalle, decimal precioPasaje) {
      this.Id = id;
      this.Detalle = detalle;
      this.Cantidad = cantidad;
      this.PrecioPasaje = precioPasaje;
    }
  }
}
