using Reservas.Dominio.Events.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Events.Reservas {
  public class ReservaCanceladaEventTest {
    [Fact]
    public void ReservaCanceladaEvent_CheckPropertiesValid() {
      var reservaIdTest = Guid.NewGuid();
      var vueloIdtest = Guid.NewGuid();

      var obj = new ReservaCanceladaEvent(
          reservaIdTest,
          vueloIdtest);

      Assert.Equal(reservaIdTest, obj.ReservaId);
      Assert.Equal(vueloIdtest, obj.VueloId);

    }
  }
}
