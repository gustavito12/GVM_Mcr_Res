using Reservas.Dominio.Models.Clientes;
using Reservas.Dominio.Models.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Dominio.Models.Clientes {
  public class ClienteTest {
    [Fact]
    public void Cliente_CheckPropertiesValid() {
      var nombreCompletoTest = "JUAN MAMANI";

      var obj = new Cliente(nombreCompletoTest);

      Assert.Equal(nombreCompletoTest, obj.NombreCompleto);
    }

    [Fact]
    public void TestConstructor_IsPrivate() {
      var command = (Cliente)Activator.CreateInstance(typeof(Cliente), true);
      Assert.Equal(Guid.Empty, command.Id);
    }
  }
}
