using Reservas.Dominio.Factories.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Factories.Pagos {
  public class PagoFactoryTest {
    [Fact]
    public void Create_Correctly() {
      var nroComprobanteTest = "45874";
      var factory = new PagoFactory();
      var pago = factory.Create(nroComprobanteTest);

      Assert.NotNull(pago);
      Assert.Equal(nroComprobanteTest, pago.CodComprobante);

    }
  }
}
