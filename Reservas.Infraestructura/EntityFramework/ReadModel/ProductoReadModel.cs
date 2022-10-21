using System;
using System.ComponentModel.DataAnnotations;

namespace Reservas.Infraestructure.EntityFramework.ReadModel {
  public class ProductoReadModel {
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public decimal PrecioVenta { get; set; }
    public int StockActual { get; set; }
  }
}
