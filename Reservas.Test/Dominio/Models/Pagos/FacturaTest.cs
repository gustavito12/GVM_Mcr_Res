using Reservas.Dominio.Models.Clientes;
using Reservas.Dominio.Models.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Models.Pagos {
  public class FacturaTest {
    [Fact]
    public void Cliente_CheckPropertiesValid() {
      var nroFacturaTest = "456789";

      var obj = new Factura(nroFacturaTest);

      Assert.Equal(nroFacturaTest, obj.NroFactura);
    }

    [Fact]
    public void TestConstructor_IsPrivate() {
      var command = (Factura)Activator.CreateInstance(typeof(Factura), true);
      Assert.Equal(Guid.Empty, command.Id);
    }
  }
}
