using Reservas.Dominio.Models.Pagos.ValueObjetcs;
using Reservas.Dominio.Models.Reservas.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Models.Reservas.ValueObjects {
  public class CodigoReservaValueTest {
    [Fact]
    public void CodigoReservaValue_CheckPropertiesValid() {
      var value = "456789";
      var codReservaTest = new CodigoReservaValue(value);
      Assert.Equal("456789", codReservaTest);

    }
  }
}
