using Reservas.Aplicacion.UsesCases.Commands.Pagos.CrearFactura;
using Reservas.Aplicacion.UsesCases.Commands.Reservas.CancelarReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Aplicacion.UsesCases.Commands {
  public class CancelarReservaCommandTest {
    [Fact]
    public void IsRequest_Valid() {
      var reservaId = Guid.NewGuid();
      var command = new CancelarReservaCommand(reservaId);

      Assert.Equal(reservaId, command.ReservaId);
    }

    //[Fact]
    //public void TestConstructor_IsPrivate()
    //{
    //    var command = (CancelarReservaCommand)Activator.CreateInstance(typeof(CancelarReservaCommand), true);
    //}
  }
}
