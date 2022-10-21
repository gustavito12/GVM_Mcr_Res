using Reservas.Dominio.Models.Pagos.ValueObjetcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Models.Pagos.ValueObjects {
  public class CodigoComprobanteValueTest {
    [Fact]
    public void CodigoComprobanteValue_CheckPropertiesValid() {
      var value = "456789";
      var codComprobanteTest = new CodigoComprobanteValue(value);
      Assert.Equal("456789", codComprobanteTest);

    }
  }
}
