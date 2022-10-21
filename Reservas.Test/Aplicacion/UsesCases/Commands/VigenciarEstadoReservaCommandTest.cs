using Reservas.Aplicacion.UsesCases.Commands.Pagos.CrearFactura;
using Reservas.Aplicacion.UsesCases.Commands.Reservas.VigenciarEstadoReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Aplicacion.UsesCases.Commands {
  public class VigenciarEstadoReservaCommandTest {
    [Fact]
    public void IsRequest_Valid() {
      Guid IdTest = Guid.NewGuid();
      var command = new VigenciarEstadoReservaCommand(IdTest);

    }

    //[Fact]
    //public void TestConstructor_IsPrivate() {
    //  var command = (VigenciarEstadoReservaCommand)Activator.CreateInstance(typeof(VigenciarEstadoReservaCommand), true);
    //}
  }
}
