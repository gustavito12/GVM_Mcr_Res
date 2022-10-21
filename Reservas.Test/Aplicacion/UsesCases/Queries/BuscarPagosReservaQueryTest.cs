using Reservas.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturasReserva;
using Reservas.Aplicacion.UsesCases.Queries.Pagos.BuscarPagosReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Aplicacion.UsesCases.Queries {
  public class BuscarPagosReservaQueryTest {
    [Fact]
    public void BuscarPagosReservaQuery_CheckPropertiesValid() {
      var idTest = Guid.NewGuid();
      var obj = new BuscarPagosReservaQuery();

      Assert.NotEqual(idTest, obj.ReservaId);
    }
  }
}
