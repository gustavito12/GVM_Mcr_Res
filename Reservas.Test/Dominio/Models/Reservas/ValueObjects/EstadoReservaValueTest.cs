using Reservas.Dominio.Models.Pagos.ValueObjetcs;
using Reservas.Dominio.Models.Reservas.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Models.Reservas.ValueObjects {
  public class EstadoReservaValueTest {
    [Fact]
    public void EstadoReservaValue_CheckPropertiesValid() {
      var value = "C";
      var estadoReservaTest = new EstadoReservaValue(value);
      Assert.Equal("C", estadoReservaTest);

    }
  }
}
