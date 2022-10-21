using Reservas.Dominio.Events.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Events.Reservas {
  public class PagoCompletadoEventTest {

    [Fact]
    public void PagoCompletadoEvent_CheckPropertiesValid() {
      var reservaIdTest = Guid.NewGuid();
      var montoTest = 18;

      var obj = new PagoCompletadoEvent(
          reservaIdTest,
          montoTest);

      Assert.Equal(reservaIdTest, obj.ReservaId);
      Assert.Equal(montoTest, obj.Monto);

    }
  }
}
