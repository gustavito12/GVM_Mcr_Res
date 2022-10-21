using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Reservas.Aplicacion.Services.Reservas;
using Reservas.Aplicacion.UsesCases.ManejadorRabbit;
using Reservas.Dominio.Factories;
using Reservas.Dominio.Factories.Pagos;
using Reservas.Dominio.Factories.Reservas;
using Reservas.Dominio.Factories.Vuelos;
using Shared.Rabbitmq.BusRabbit;
using Shared.Rabbitmq.EventoQueue;
using Shared.Rabbitmq.Implement;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion {
  [ExcludeFromCodeCoverage]
  public static class Extensions {
    public static IServiceCollection AddApplication(this IServiceCollection services) {
      services.AddMediatR(Assembly.GetExecutingAssembly());
      services.AddTransient<IReservaService, ReservaService>();
      services.AddTransient<IReservaFactory, ReservaFactory>();

      services.AddTransient<IPagoService, PagoService>();
      services.AddTransient<IPagoFactory, PagoFactory>();

      services.AddTransient<IFacturaService, FacturaService>();
      services.AddTransient<IFacturaFactory, FacturaFactory>();

      services.AddSingleton<IProductoFactory, ProductoFactory>();
      services.AddSingleton<IVueloFactory, VueloFactory>();

      AddRabbitMq(services);

      return services;
    }

    private static void AddRabbitMq(this IServiceCollection services) {
      ///<Sumary>
      ///Se agrega el bus de RabbitMQ, sera utiliza para cualquier microservicio.
      ///Para el PRODUCTOR (Publisher) y tambien para el CONSUMIDOR
      ///<Sumary>
      services.AddTransient<IRabbitEventBus, RabbitEventBus>();

      ///<Sumary>
      ///Se agrega el eventomanejador de RabbitMQ.
      ///Para el CONSUMIDOR (Subscriber), implementacion de evento manejador
      ///<Sumary>
      services.AddTransient<IEventoManejador<VueloAsignadoReservaQueue>, ReservaEventoManejador>();
      services.AddTransient<IEventoManejador<CheckinAsignadoEventoQueue>, CheckinEventoManejador>();

    }

  }
}
