using Reservas.Dominio.Factories;
using Reservas.Dominio.Factories.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Factories {
  public class ProductoFactoryTest {
    [Fact]
    public void Create_Correctly() {
      var idTest = Guid.NewGuid();
      var nombreTest = "cocacola";
      var precioVentaTest = 20;
      var stockActualtest = 10;

      var factory = new ProductoFactory();
      var producto = factory.Create(idTest, nombreTest, precioVentaTest, stockActualtest);

      Assert.NotNull(producto);
      Assert.Equal(idTest, producto.Id);
      Assert.Equal(nombreTest, producto.Nombre);
      Assert.Equal(precioVentaTest, producto.PrecioVenta);

    }
  }
}
