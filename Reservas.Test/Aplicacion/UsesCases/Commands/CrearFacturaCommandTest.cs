using Reservas.Aplicacion.UsesCases.Commands.Pagos.CrearFactura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Aplicacion.UsesCases.Commands {
  public class CrearFacturaCommandTest {

    [Fact]
    public void IsRequest_Valid() {
      var reservaId = Guid.NewGuid();
      var montoTest = 50;
      var command = new CrearFacturaCommand(reservaId, montoTest);

      Assert.Equal(reservaId, command.ReservaId);
    }

    //[Fact]
    //public void TestConstructor_IsPrivate()
    //{
    //    var command = (CrearFacturaCommand)Activator.CreateInstance(typeof(CrearFacturaCommand), true);
    //    Assert.Null(command.ReservaId);
    //}

  }
}
