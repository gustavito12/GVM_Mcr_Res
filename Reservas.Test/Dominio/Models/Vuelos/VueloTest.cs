using Reservas.Dominio.Models.Reservas;
using Reservas.Dominio.Models.Vuelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Models.Vuelos {
  public class VueloTest {
    [Fact]
    public void Vuelo_CheckPropertiesValid() {
      var cantidadTest = 22;
      var detalleTest = "Normal";
      var precioPasajeTest = 45;

      var obj = new Vuelo(cantidadTest, detalleTest, precioPasajeTest);
      Assert.Equal(cantidadTest, obj.Cantidad);
      Assert.Equal(detalleTest, obj.Detalle);
      Assert.Equal(precioPasajeTest, obj.PrecioPasaje);
    }

    //[Fact]
    //public void TestConstructor_IsPrivate()
    //{
    //    var command = (Vuelo)Activator.CreateInstance(typeof(Vuelo), true);
    //    Assert.Equal(Guid.Empty, command.Id);
    //}
  }
}
