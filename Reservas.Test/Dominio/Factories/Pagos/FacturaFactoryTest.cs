using Reservas.Dominio.Factories.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Factories.Pagos {
  public class FacturaFactoryTest {
    [Fact]
    public void Create_Correctly() {
      var nroComprobanteTest = "45874";
      var factory = new FacturaFactory();
      var factura = factory.Create(nroComprobanteTest);

      Assert.NotNull(factura);
      Assert.Equal(nroComprobanteTest, factura.NroFactura);

    }
  }
}
