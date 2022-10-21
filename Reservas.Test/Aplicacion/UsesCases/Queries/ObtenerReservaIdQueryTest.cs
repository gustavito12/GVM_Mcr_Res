using Reservas.Aplicacion.UsesCases.Queries.Pagos.BuscarPagosReserva;
using Reservas.Aplicacion.UsesCases.Queries.Reservas.ObtenerReservaId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Aplicacion.UsesCases.Queries {
  public class ObtenerReservaIdQueryTest {
    [Fact]
    public void ObtenerReservaIdQuery_CheckPropertiesValid() {
      var idTest = Guid.NewGuid();
      var obj = new ObtenerReservaIdQuery(idTest);
      var ob1j = new ObtenerReservaIdQuery();

      Assert.Equal(idTest, obj.Id);
    }
  }
}
