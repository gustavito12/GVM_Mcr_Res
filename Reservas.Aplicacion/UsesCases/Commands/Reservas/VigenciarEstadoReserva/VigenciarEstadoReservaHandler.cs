using Microsoft.Extensions.Logging;
using Reservas.Aplicacion.Services.Reservas;
using Reservas.Aplicacion.UsesCases.Commands.Reservas.CancelarReserva;
using Reservas.Dominio.Factories.Reservas;
using Reservas.Dominio.Repositories.Reservas;
using Reservas.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Reservas.Dominio.Models.Reservas;
using MediatR;

namespace Reservas.Aplicacion.UsesCases.Commands.Reservas.VigenciarEstadoReserva {
  public class VigenciarEstadoReservaHandler : IRequestHandler<VigenciarEstadoReservaCommand, Guid> {

    private readonly IReservaRepository _reservaRepository;
    private readonly ILogger<VigenciarEstadoReservaHandler> _logger;
    private readonly IReservaService _reservaService;
    private readonly IReservaFactory _reservaFactory;
    private readonly IUnitOfWork _unitOfWork;

    public VigenciarEstadoReservaHandler(IReservaRepository reservaRepository, ILogger<VigenciarEstadoReservaHandler> logger,
        IReservaService reservaService, IReservaFactory reservaFactory, IUnitOfWork unitOfWork) {
      _reservaRepository = reservaRepository;
      _logger = logger;
      _reservaService = reservaService;
      _reservaFactory = reservaFactory;
      _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(VigenciarEstadoReservaCommand request, CancellationToken cancellationToken) {
      try {
        Reserva objReserva = await _reservaRepository.FindByIdAsync(request.Id);
        objReserva.ActualizaIngresoReservaCheckin();
        await _reservaRepository.UpdateAsync(objReserva);
        await _unitOfWork.Commit();
        return objReserva.Id;
      } catch (Exception ex) {
        _logger.LogError(ex, "Error al marcar la Reserva Checkin");
      }
      return Guid.Empty;

    }
  }
}
