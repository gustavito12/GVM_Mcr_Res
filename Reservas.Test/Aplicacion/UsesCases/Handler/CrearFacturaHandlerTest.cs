using Microsoft.Extensions.Logging;
using Reservas.Aplicacion.Services.Reservas;
using Reservas.Aplicacion.UsesCases.Commands.Pagos.CrearFactura;
using Reservas.Dominio.Factories.Pagos;
using Reservas.Dominio.Repositories.Pagos;
using Reservas.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Reservas.Dominio.Models.Pagos;
using System.Threading;
using Xunit;
using Reservas.Dominio.Models.Reservas;
using Reservas.Test.Dominio.Models.Vuelos;
using static Moq.It;
using ShareKernel.Cores;

namespace Reservas.Test.Aplicacion.UsesCases.Handler {
  public class CrearFacturaHandlerTest {
    private readonly Mock<IFacturaRepository> _facturaRepository;
    private readonly Mock<ILogger<CrearFacturaHandler>> _logger;
    private readonly Mock<IFacturaService> _facturaService;
    private readonly Mock<IFacturaFactory> _facturaFactory;
    private readonly Mock<IUnitOfWork> _unitOfWork;

    private Factura objFacturaTest;

    public CrearFacturaHandlerTest() {
      _facturaRepository = new Mock<IFacturaRepository>();
      _facturaService = new Mock<IFacturaService>();
      _facturaFactory = new Mock<IFacturaFactory>();
      _unitOfWork = new Mock<IUnitOfWork>();
    }

    [Fact]
    public void CrearFacturaHandlerTest_Handle_Correctly() {
      try {
        string nroFactura = "45678";
        var objFacturaTest = new Factura(nroFactura);

        _facturaFactory.Setup(facturaFactory => facturaFactory.Create(objFacturaTest.NroFactura)).Returns(objFacturaTest);


        var objHandler = new CrearFacturaHandler(
            _facturaRepository.Object,
            _facturaService.Object,
            _facturaFactory.Object,
            _unitOfWork.Object);

        var requestTest = new CrearFacturaCommand(objFacturaTest.Id, 45);

        var tcs = new CancellationTokenSource(1000);
        var result = objHandler.Handle(requestTest, tcs.Token);


        //_facturaRepository.Verify(mock => mock.CreateAsync(IsAny<Factura>()), Times.Once);
        //_unitOfWork.Verify(mock => mock.Commit(), Times.Once);

        //Assert.NotEqual(Guid.NewGuid(), objFacturaTest.Id);

        //Assert.IsType<Guid>(result.Result);
      } catch (Exception ex) {
        _logger.Setup(lo => lo.LogError(ex, "Error al crear Factura"));
        throw new BussinessRuleValidationException(ex.Message);
      }
    }
  }
}
