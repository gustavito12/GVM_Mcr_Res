using Reservas.Aplicacion.UsesCases.Commands.Pagos.CrearFactura;
using Reservas.Aplicacion.UsesCases.Commands.Pagos.CrearPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Aplicacion.UsesCases.Commands {
  public class CrearPagoCommandTest {
    [Fact]
    public void IsRequest_Valid() {
      var reservaId = Guid.NewGuid();
      var montoTest = 50;
      var command = new CrearPagoCommand(reservaId, montoTest);

      Assert.Equal(reservaId, command.ReservaId);
    }

    //[Fact]
    //public void TestConstructor_IsPrivate()
    //{
    //    var command = (CrearPagoCommand)Activator.CreateInstance(typeof(CrearPagoCommand), true);
    //    Assert.Null(command.ReservaId);
    //}
  }
}
