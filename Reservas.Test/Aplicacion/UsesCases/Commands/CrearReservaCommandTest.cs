using Reservas.Aplicacion.UsesCases.Commands.Pagos.CrearFactura;
using Reservas.Aplicacion.UsesCases.Commands.Reservas.CrearReserva;
using Reservas.Dominio.Models.Reservas;
using Reservas.Dominio.Models.Vuelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Aplicacion.UsesCases.Commands {
  public class CrearReservaCommandTest {
    [Fact]
    public void IsRequest_Valid() {
      var clienteIdTest = Guid.NewGuid();
      var vueloIdTest = Guid.NewGuid();
      var tipoReservaTest = "normal";
      var command = new CrearReservaCommand(clienteIdTest, vueloIdTest, tipoReservaTest);

      Assert.Equal(clienteIdTest, command.clienteId);
      Assert.Equal(vueloIdTest, command.vueloId);
      Assert.Equal(tipoReservaTest, command.tipoReserva);
    }

    //[Fact]
    //public void TestConstructor_IsPrivate()
    //{
    //    var command = (CrearFacturaCommand)Activator.CreateInstance(typeof(CrearFacturaCommand), true);
    //    Assert.Null(command.ReservaId);
    //}
  }
}
