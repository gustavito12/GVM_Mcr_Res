using Reservas.Dominio.Model.Productos;
using System;

namespace Reservas.Dominio.Factories {
  public interface IProductoFactory {
    Producto Create(Guid id, string nombre, decimal precioVenta, int stockActual);
  }
}
