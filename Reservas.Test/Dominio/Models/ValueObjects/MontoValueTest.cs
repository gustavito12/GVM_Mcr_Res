using Reservas.Dominio.Models.Reservas.ValueObjects;
using Reservas.Dominio.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Models.ValueObjects {
  public class MontoValueTest {
    [Fact]
    public void MontoValue_CheckPropertiesValid() {
      var value = 50;
      var montoTest = new MontoValue(value);
      Assert.Equal(50, montoTest);

    }
  }
}
