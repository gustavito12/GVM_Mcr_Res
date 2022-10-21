using Reservas.Dominio.Models.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Models.Pagos {
  public class PagoTest {
    [Fact]
    public void Cliente_CheckPropertiesValid() {
      var codComprobanteTest = "456789";

      var obj = new Pago(codComprobanteTest);

      Assert.Equal(codComprobanteTest, obj.CodComprobante);
    }

    [Fact]
    public void TestConstructor_IsPrivate() {
      var command = (Pago)Activator.CreateInstance(typeof(Pago), true);
      Assert.Equal(Guid.Empty, command.Id);
    }
  }
}
