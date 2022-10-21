
using Reservas.Dominio.Factories;
using Reservas.Dominio.Model.Productos;
using System;

namespace Reservas.Dominio.Factories {
  public class ProductoFactory : IProductoFactory {
    public Producto Create(Guid id, string nombre, decimal precioVenta, int stockActual) {
      return new Producto(id, nombre, precioVenta, stockActual);
    }
  }
}
