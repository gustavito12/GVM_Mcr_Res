using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Aplicacion.Services.Reservas;
using Reservas.Dominio.Factories.Reservas;
using Reservas.Dominio.Models.Reservas;
using Reservas.Dominio.Models.Vuelos;
using Reservas.Dominio.Repositories;
using Reservas.Dominio.Repositories.Reservas;
using Reservas.Dominio.Repositories.Vuelos;
using Shared.Rabbitmq.BusRabbit;
using Shared.Rabbitmq.EventoQueue;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Commands.Reservas.CrearReserva {
  [ExcludeFromCodeCoverage]
  public class CrearReservaHandler : IRequestHandler<CrearReservaCommand, Guid> {
    private readonly IReservaRepository _reservaRepository;
    private readonly IVueloRepository _vueloRepository;
    private readonly ILogger<CrearReservaHandler> _logger;
    private readonly IReservaService _reservaService;
    private readonly IReservaFactory _reservaFactory;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Se implementa EventBus de RabbitMQ
    /// </summary>
    /// <param name="eventBus"></param>
    private readonly IRabbitEventBus _eventBus;

    public CrearReservaHandler(IReservaRepository reservaRepository, ILogger<CrearReservaHandler> logger,
        IReservaService reservaService, IReservaFactory reservaFactory, IUnitOfWork unitOfWork, IVueloRepository vueloRepository, IRabbitEventBus eventBus) {
      _reservaRepository = reservaRepository;
      _logger = logger;
      _reservaService = reservaService;
      _reservaFactory = reservaFactory;
      _unitOfWork = unitOfWork;
      _vueloRepository = vueloRepository;
      _eventBus = eventBus;

    }
    public async Task<Guid> Handle(CrearReservaCommand request, CancellationToken cancellationToken) {
      try {
        Vuelo objVuelo = await _vueloRepository.FindByIdAsync(request.vueloId);
        if (objVuelo.Cantidad > 0) {
          string nroReserva = await _reservaService.GenerarNroReservaAsync();

          Reserva objReserva = _reservaFactory.Create(nroReserva);

          objReserva.CrearReserva(request.clienteId, request.vueloId, objVuelo.PrecioPasaje, request.tipoReserva);
          objReserva.ConsolidarReserva();

          //await _reservaService.EnviarEmailReserva(objReserva);

          await _reservaRepository.CreateAsync(objReserva);

          await _unitOfWork.Commit();

          //Publicando RabbitMQ            
          //_eventBus.Publish(new AeronaveAgregadaEventoQueue(objaeronave.Id, request.Marca, request.Modelo, request.NroAsientos, objaeronave.EstadoAeronave, "Se Creo la Aeronave y se notifica al bus de eventos"));
          //_eventBus.Publish(new ReservaAgregadaEventoQueue(objaeronave.Id, request.Marca, request.Modelo, request.NroAsientos, objaeronave.EstadoAeronave, "Se Creo la Aeronave y se notifica al bus de eventos"));
          //_eventBus.Publish(new ReservaAgregadaEventoQueue(objReserva.Id, objReserva.ClienteId, objReserva.VueloId, objReserva.TipoReserva, objVuelo.PrecioPasaje));
          _eventBus.Publish(new ReservaAgregadaEventoQueue(objReserva.Id, objReserva.CodReserva, objReserva.EstadoReserva, objReserva.Monto, objReserva.Fecha, objReserva.TipoReserva, objReserva.ClienteId, objReserva.VueloId));
          //_eventBus.Publish(new VueloAsignadoAeronaveQueue(Guid.NewGuid(), Guid.NewGuid(), objaeronave.Id));

          return objReserva.Id;
        } else {
          Console.WriteLine("No existe asientos Disponibles");
          return Guid.Empty;
        }
      } catch (Exception ex) {
        _logger.LogError(ex, "Error al crear Reserva");
      }
      return Guid.Empty;

    }



  }
}
