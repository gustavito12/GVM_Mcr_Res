using Pedidos.Domain.Model.ValueObjects;
using Pedidos.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.ValueObjects {
  public class PrecioValueTest {
    [Fact]
    public void PrecioValue_CheckPropertiesValid() {
      var value = 100;
      var precioTest = new PrecioValue(value);
      Assert.Equal(100, precioTest);

    }
  }
}
