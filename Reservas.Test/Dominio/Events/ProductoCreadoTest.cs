using Pedidos.Domain.Event;
using Reservas.Dominio.Events.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Events {
  public class ProductoCreadoTest {
    [Fact]
    public void ProductoCreado_CheckPropertiesValid() {
      var productoIdTest = Guid.NewGuid();
      var nombreTest = "prueba";
      var stockActualTest = 50;
      var precioVentaTest = 90;

      var obj = new ProductoCreado(
              productoIdTest,
              nombreTest,
              stockActualTest,
              precioVentaTest);

      Assert.Equal(productoIdTest, obj.ProductoId);
      Assert.Equal(nombreTest, obj.Nombre);
      Assert.Equal(stockActualTest, obj.StockActual);
      Assert.Equal(precioVentaTest, obj.PrecioVenta);

    }
  }
}
