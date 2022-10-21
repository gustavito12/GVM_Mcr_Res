using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Reservas.Aplicacion.UsesCases.ManejadorRabbit;
using Shared.Rabbitmq.BusRabbit;
using Shared.Rabbitmq.EventoQueue;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion {
  [ExcludeFromCodeCoverage]
  public static class ExtensionsApp {
    public static IApplicationBuilder RabbitMQConsumer(this IApplicationBuilder app) {

      ///<Sumary>
      ///registrar el evento Queue del bus
      ///Para el CONSUMIDOR (Subscriber) al evento ejemplo EmailEventoQueue que esta en el bus
      ///<Sumary>
      var eventBus = app.ApplicationServices.GetRequiredService<IRabbitEventBus>();
      //eventBus.Subscribe<EmailEventoQueue, EmailEventoManejador>();
      //eventBus.Subscribe<AeronaveAgregadaEventoQueue, AeronaveEventoManejador>();

      eventBus.Subscribe<VueloAsignadoReservaQueue, ReservaEventoManejador>();
      eventBus.Subscribe<CheckinAsignadoEventoQueue, CheckinEventoManejador>();

      return app;
    }
  }
}
