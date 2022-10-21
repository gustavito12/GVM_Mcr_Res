using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Aplicacion.Services.Reservas;
using Reservas.Aplicacion.UsesCases.Commands.Reservas.CrearReserva;
using Reservas.Dominio.Factories.Reservas;
using Reservas.Dominio.Models.Reservas;
using Reservas.Dominio.Models.Vuelos;
using Reservas.Dominio.Repositories.Reservas;
using Reservas.Dominio.Repositories.Vuelos;
using Reservas.Dominio.Repositories;
using Shared.Rabbitmq.BusRabbit;
using Shared.Rabbitmq.EventoQueue;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Reservas.Dominio.Factories.Vuelos;
using Reservas.Dominio.Model.Productos;

namespace Reservas.Aplicacion.UsesCases.Commands.Vuelos.CrearVuelo {
  [ExcludeFromCodeCoverage]
  public class CrearVueloHandler : IRequestHandler<CrearVueloCommand, Guid> {

    private readonly IVueloRepository _vueloRepository;
    private readonly ILogger<CrearVueloHandler> _logger;
    private readonly IVueloFactory _vueloFactory;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Se implementa EventBus de RabbitMQ
    /// </summary>
    /// <param name="eventBus"></param>
    private readonly IRabbitEventBus _eventBus;

    public CrearVueloHandler(IVueloRepository vueloRepository, ILogger<CrearVueloHandler> logger,
                        IVueloFactory vueloFactory, IUnitOfWork unitOfWork, IRabbitEventBus eventBus) {
      _vueloRepository = vueloRepository;
      _logger = logger;
      _vueloFactory = vueloFactory;
      _unitOfWork = unitOfWork;
      _vueloRepository = vueloRepository;
      _eventBus = eventBus;

    }
    public async Task<Guid> Handle(CrearVueloCommand request, CancellationToken cancellationToken) {
      try {
        Vuelo objVuelo = _vueloFactory.Create(request.Id, request.Cantidad, request.Detalle, request.PrecioPasaje);
        objVuelo.ConsolidarVuelo();

        await _vueloRepository.CreateAsync(objVuelo);
        await _unitOfWork.Commit();

        return objVuelo.Id;
      } catch (Exception ex) {
        _logger.LogError(ex, "Error al crear vuelo");
      }
      return Guid.Empty;

    }
  }
}
