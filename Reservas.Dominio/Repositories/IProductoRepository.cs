using Reservas.Dominio.Model.Productos;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Dominio.Repositories {
  public interface IProductoRepository : IRepository<Producto, Guid> {
    Task UpdateAsync(Producto obj);

    Task RemoveAsync(Producto obj);

  }
}
