using Pedidos.Domain.Model.ValueObjects;
using Reservas.Dominio.Models.Reservas.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Models.ValueObjects {
  public class CantidadValueTest {
    [Fact]
    public void CantidadValue_CheckPropertiesValid() {
      var value = 1;
      var cantidadTest = new CantidadValue(value);
      Assert.Equal(1, Convert.ToInt32(cantidadTest));

    }
  }
}
