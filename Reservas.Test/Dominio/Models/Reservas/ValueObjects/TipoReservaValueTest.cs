using Reservas.Dominio.Models.Pagos.ValueObjetcs;
using Reservas.Dominio.Models.Reservas.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Models.Reservas.ValueObjects {
  public class TipoReservaValueTest {
    [Fact]
    public void TipoReservaValue_CheckPropertiesValid() {
      var value = "normal";
      var tipoReservaTest = new TipoReservaValue(value);
      Assert.Equal("normal", tipoReservaTest);

    }
  }
}
