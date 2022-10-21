using Reservas.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturaPorId;
using Reservas.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturasReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Aplicacion.UsesCases.Queries {
  public class BuscarFacturasReservaQueryTest {
    [Fact]
    public void BuscarFacturasReservaQuery_CheckPropertiesValid() {
      var idTest = Guid.NewGuid();
      var obj = new BuscarFacturasReservaQuery();

      Assert.NotEqual(idTest, obj.ReservaId);
    }
  }
}
