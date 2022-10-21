using Pedidos.Application.Dto.Producto;
using Reservas.Aplicacion.Dtos.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Aplicacion.Dtos {
  public class ProductoDtoTest {
    [Fact]
    public void ProductoDto_CheckPropertiesValid() {
      var idProducto = Guid.NewGuid();
      var PrecioVenta = 50;
      var stockActual = 50;

      var objProducto = new ProductoDto();
      Assert.Equal(Guid.Empty, objProducto.Id);

      objProducto.Id = idProducto;
      objProducto.PrecioVenta = PrecioVenta;
      objProducto.StockActual = stockActual;

      Assert.Equal(idProducto, objProducto.Id);
      Assert.Equal(PrecioVenta, objProducto.PrecioVenta);
      Assert.Equal(stockActual, objProducto.StockActual);



    }
  }
}
