using Reservas.Dominio.Model.Productos;
using Reservas.Dominio.Models.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Models.Reservas {
  public class ReservaTest {
    [Fact]
    public void Reserva_CheckPropertiesValid() {
      var nroReservaTest = "45874";
      var obj = new Reserva(nroReservaTest);
      Assert.Equal(nroReservaTest, obj.CodReserva);
    }

    [Fact]
    public void TestConstructor_IsPrivate() {
      var command = (Reserva)Activator.CreateInstance(typeof(Reserva), true);
      Assert.Equal(Guid.Empty, command.Id);
    }
  }
}
