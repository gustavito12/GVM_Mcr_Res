using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Dominio.Factories;
using Reservas.Dominio.Model.Productos;
using Reservas.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Commands.Productos {
  [ExcludeFromCodeCoverage]
  public class CrearProductoHandler : IRequestHandler<CrearProductoCommand, Guid> {
    private readonly IProductoRepository _productoRepository;
    private readonly ILogger<CrearProductoHandler> _logger;
    private readonly IProductoFactory _productoFactory;
    private readonly IUnitOfWork _unitOfWork;

    public CrearProductoHandler(IProductoRepository productoRepository, ILogger<CrearProductoHandler> logger, IProductoFactory productoFactory, IUnitOfWork unitOfWork) {
      _productoRepository = productoRepository;
      _logger = logger;
      _productoFactory = productoFactory;
      _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CrearProductoCommand request, CancellationToken cancellationToken) {
      try {
        Producto objProducto = _productoFactory.Create(request.ArticuloId, request.Nombre, request.PrecioVenta, request.StockActual);
        objProducto.ConsolidarProducto();

        await _productoRepository.CreateAsync(objProducto);
        await _unitOfWork.Commit();

        return objProducto.Id;
      } catch (Exception ex) {
        _logger.LogError(ex, "Error al crear producto");
      }
      return Guid.Empty;
    }
  }
}
