using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reservas.Aplicacion;
using Reservas.Infraestructura;
using MassTransit;
using Shared.Rabbitmq.BusRabbit;
using Shared.Rabbitmq.Implement;

namespace Reservas.WebApi {
  public class Startup {
    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      services.AddInfrastructure(Configuration);
      //services.AddTransient<IRabbitEventBus, RabbitEventBus>();
      //services.AddMassTransit(x =>
      //{
      //    x.AddConsumer<ArticuloCreadoConsumer>();
      //    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
      //    {
      //        //cfg.UseHealthCheck(provider);
      //        cfg.Host(new Uri("rabbitmq://localhost"), h =>
      //        {
      //            h.Username("guest");
      //            h.Password("guest");
      //        });
      //        cfg.ReceiveEndpoint("ticketQueue", ep =>
      //        {
      //            ep.PrefetchCount = 16;
      //            ep.UseMessageRetry(r => r.Interval(2, 100));
      //            ep.ConfigureConsumer<ArticuloCreadoConsumer>(provider);
      //        });
      //    }));
      //});
      //services.AddMassTransitHostedService();

      services.AddControllers();
      services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Reservas.WebApi", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      // if (env.IsDevelopment())
      //{
      app.UseDeveloperExceptionPage();
      app.UseSwagger();
      app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reservas.WebApi v1"));
      //}

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });

      app.RabbitMQConsumer();
    }
  }
}
