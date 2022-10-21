using Newtonsoft.Json;
using Reservas.Dominio.Models.Vuelos;
using Shared.Rabbitmq.BusRabbit;
using Shared.Rabbitmq.EventoQueue;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.ManejadorRabbit {
  public class CheckinEventoManejador : IEventoManejador<CheckinAsignadoEventoQueue> {
    public Task Handle(CheckinAsignadoEventoQueue @evento) {

      //var url = "https://aeronave.azurewebsites.net/api/Vuelo";          
      var url = "https://localhost:44378/api/Reserva/MarcaCheckin";
      var request = (HttpWebRequest)WebRequest.Create(url);
      request.Accept = "application/json";
      request.ContentType = "application/json";
      request.Method = "POST";
      request.Timeout = 300000;
      var json = JsonConvert.SerializeObject(@evento);

      ASCIIEncoding encoding = new ASCIIEncoding();
      Byte[] bytes = encoding.GetBytes(json);

      Stream newStream = request.GetRequestStream();
      newStream.Write(bytes, 0, bytes.Length);
      newStream.Close();

      // Invocación del servicio y respuesta
      var response = request.GetResponse();

      return Task.CompletedTask;

    }
  }
}
