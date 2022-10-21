using Reservas.Dominio.Factories.Pagos;
using Reservas.Dominio.Factories.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Factories.Reservas {
  public class ReservaFactoryTest {
    [Fact]
    public void Create_Correctly() {
      var nroReservaTest = "45874";
      var factory = new ReservaFactory();
      var reserva = factory.Create(nroReservaTest);

      Assert.NotNull(reserva);
      Assert.Equal(nroReservaTest, reserva.CodReserva);

    }
  }
}
