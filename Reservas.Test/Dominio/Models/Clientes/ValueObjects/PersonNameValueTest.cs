using Pedidos.Domain.Model.ValueObjects;
using Reservas.Dominio.Models.Clientes.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Models.Clientes.ValueObjects {
  public class PersonNameValueTest {
    [Fact]
    public void PersonNameValue_CheckPropertiesValid() {
      var value = "JUAN";
      var nonbreClienteTest = new PersonNameValue(value);
      Assert.Equal("JUAN", nonbreClienteTest);

    }
  }
}
