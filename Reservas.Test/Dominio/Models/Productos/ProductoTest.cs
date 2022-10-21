using Reservas.Dominio.Factories;
using Reservas.Dominio.Model.Productos;
using Reservas.Dominio.Models.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Models.Productos {
  public class ProductoTest {
    [Fact]
    public void Cliente_CheckPropertiesValid() {
      var idTest = Guid.NewGuid();
      var nombreTest = "cocacola";
      var precioVentaTest = 20;
      var stockActualtest = 10;

      var obj = new Producto(idTest, nombreTest, precioVentaTest, stockActualtest);

      Assert.Equal(idTest, obj.Id);
      Assert.Equal(nombreTest, obj.Nombre);
      Assert.Equal(precioVentaTest, obj.PrecioVenta);
    }

    [Fact]
    public void TestConstructor_IsPrivate() {
      var command = (Producto)Activator.CreateInstance(typeof(Producto), true);
      Assert.Equal(Guid.Empty, command.Id);
    }
  }
}
