using Reservas.Aplicacion.UsesCases.Commands.Pagos.CrearFactura;
using Reservas.Aplicacion.UsesCases.Commands.Productos;
using Reservas.Dominio.Models.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Aplicacion.UsesCases.Commands {
  public class CrearProductoCommandTest {
    [Fact]
    public void IsRequest_Valid() {
      var articuloIdTest = Guid.NewGuid();
      var stockActualTest = 50;
      var precioVentaTest = 2;
      var nombreTest = "cocacola";


      var command = new CrearProductoCommand(articuloIdTest, stockActualTest, precioVentaTest, nombreTest);

      Assert.Equal(articuloIdTest, command.ArticuloId);
      Assert.Equal(stockActualTest, command.StockActual);
      Assert.Equal(precioVentaTest, command.PrecioVenta);
      Assert.Equal(nombreTest, command.Nombre);
    }

    //[Fact]
    //public void TestConstructor_IsPrivate()
    //{
    //    var command = (CrearProductoCommand)Activator.CreateInstance(typeof(CrearProductoCommand), true);
    //    Assert.Null(command.ArticuloId);
    //}
  }
}
