using Reservas.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturaPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Aplicacion.UsesCases.Queries {
  public class BuscarFacturaPorIdQueryTest {
    [Fact]
    public void BuscarFacturaPorIdQuery_CheckPropertiesValid() {
      var idTest = Guid.NewGuid();
      var obj = new BuscarFacturaPorIdQuery();
      var obj1 = new BuscarFacturaPorIdQuery(idTest);

      Assert.Equal(idTest, obj1.Id);
    }
  }
}
