using Reservas.Dominio.Models.Pagos.ValueObjetcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Models.Clientes.ValueObjects {
  public class NumeroFacturaValueTest {
    [Fact]
    public void NumeroFacturaValue_CheckPropertiesValid() {
      var value = "456789";
      var nroFacturaTest = new NumeroFacturaValue(value);
      Assert.Equal("456789", nroFacturaTest);

    }
  }
}
