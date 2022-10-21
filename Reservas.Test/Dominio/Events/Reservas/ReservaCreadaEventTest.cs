using Reservas.Dominio.Events.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Events.Reservas {
  public class ReservaCreadaEventTest {

    [Fact]
    public void ReservaCreadaEvent_CheckPropertiesValid() {
      var vueloIdTest = Guid.NewGuid();
      var reservaIdTest = Guid.NewGuid();
      var occuredOnTest = DateTime.Now;

      var obj = new ReservaCreadaEvent(
          vueloIdTest,
          reservaIdTest,
          occuredOnTest);

      Assert.NotEqual(reservaIdTest, obj.ReservaId);
      Assert.NotEqual(vueloIdTest, obj.VueloId);

    }
  }
}
