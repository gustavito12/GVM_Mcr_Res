using ShareKernel.Cores;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Dominio.Models.Pagos.ValueObjetcs {
  public record NumeroFacturaValue : ValueObject {
    public string Value { get; }

    public NumeroFacturaValue(string value) {
      CheckRule(new StringNotNullOrEmptyRule(value));
      //TODO: validar el formato del numero de factura
      Value = value;
    }


    public static implicit operator string(NumeroFacturaValue value) {
      return value.Value;
    }

    public static implicit operator NumeroFacturaValue(string value) {
      return new NumeroFacturaValue(value);
    }



  }
}
