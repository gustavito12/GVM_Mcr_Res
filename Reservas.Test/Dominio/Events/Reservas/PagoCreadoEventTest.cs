using Reservas.Dominio.Events.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Events.Reservas {
  public class PagoCreadoEventTest {

    [Fact]
    public void PagoCreadoEvent_CheckPropertiesValid() {
      var reservaIdTest = Guid.NewGuid();
      var montoTest = 60;

      var obj = new PagoCreadoEvent(
          reservaIdTest,
          montoTest);

      Assert.Equal(reservaIdTest, obj.ReservaId);
      Assert.Equal(montoTest, obj.Monto);

    }
  }
}
