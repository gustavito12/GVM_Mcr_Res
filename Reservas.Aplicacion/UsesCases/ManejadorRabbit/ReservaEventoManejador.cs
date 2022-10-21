using Newtonsoft.Json;
using Reservas.Dominio.Events;
using Reservas.Dominio.Models.Vuelos;
using Shared.Rabbitmq.BusRabbit;
using Shared.Rabbitmq.EventoQueue;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.ManejadorRabbit {
  [ExcludeFromCodeCoverage]
  public class ReservaEventoManejador : IEventoManejador<VueloAsignadoReservaQueue> {
    /// <summary>
    /// Clase para el CONSUMIDOR uso de RabbitMQ
    /// </summary>               
    public Task Handle(VueloAsignadoReservaQueue @evento) {
      if (evento != null) {
        Random random = new Random();
        // Recuerda que el segundo argumento es el límite
        // superior exclusivo
        // Entre 1 y 10
        int pasajero = random.Next(20, 30);
        decimal precio = random.Next(200, 500);
        int codigoDepartamento = random.Next(1, 9);
        string Departamento = VerificaDepartamento(codigoDepartamento);

        VueloCreadoEvent evento1 = new VueloCreadoEvent(evento.Id, pasajero, Departamento, precio);

        //(evento.Id,5,"TARIJA",34);

        //var url = "https://aeronave.azurewebsites.net/api/Vuelo";          
        var url = "https://localhost:44378/api/Vuelo";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Accept = "application/json";
        request.ContentType = "application/json";
        request.Method = "POST";
        request.Timeout = 300000;
        var json = JsonConvert.SerializeObject(evento1);

        ASCIIEncoding encoding = new ASCIIEncoding();
        Byte[] bytes = encoding.GetBytes(json);

        Stream newStream = request.GetRequestStream();
        newStream.Write(bytes, 0, bytes.Length);
        newStream.Close();

        // Invocación del servicio y respuesta
        var response = request.GetResponse();


      }
      return Task.CompletedTask;
    }

    public string VerificaDepartamento(int codigoDepartamento) {
      string Departamento = "BOLIVIA";

      switch (codigoDepartamento) {
        case 1:
          Departamento = "LA PAZ";
          break;
        case 2:
          Departamento = "ORURO";
          break;
        case 3:
          Departamento = "POTOSI";
          break;
        case 4:
          Departamento = "TARIJA";
          break;
        case 5:
          Departamento = "SUCRE";
          break;
        case 6:
          Departamento = "SANTA CRUZ";
          break;
        case 7:
          Departamento = "BENI";
          break;
        case 8:
          Departamento = "PANDO";
          break;
        case 9:
          Departamento = "COCHABAMBA";
          break;
      }

      return Departamento;
    }
  }
}
