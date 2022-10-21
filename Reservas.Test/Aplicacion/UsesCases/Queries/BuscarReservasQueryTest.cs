using Reservas.Aplicacion.UsesCases.Queries.Pagos.BuscarPagosReserva;
using Reservas.Aplicacion.UsesCases.Queries.Reservas.BuscarReservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Aplicacion.UsesCases.Queries {
  public class BuscarReservasQueryTest {
    [Fact]
    public void BuscarReservasQuery_CheckPropertiesValid() {
      var codReservaTest = "488255";
      var obj = new BuscarReservasQuery();

      //Assert.NotEqual(codReservaTest, obj.);
    }
  }
}
