using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas.Infraestructura.EntityFramework.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Infraestructura.EntityFramework.Config.ReadConfig {
  public class ReservaReadConfig : IEntityTypeConfiguration<ReservaReadModel> {
    public void Configure(EntityTypeBuilder<ReservaReadModel> builder) {
      builder.ToTable("Reserva");
      builder.HasKey(x => x.Id);

      builder.Property(x => x.CodReserva)
          .HasColumnName("codReserva")
          .HasMaxLength(25);

      builder.Property(x => x.EstadoReserva)
          .HasColumnName("estadoReserva")
          .HasMaxLength(6);

      builder.Property(x => x.Monto)
          .HasColumnName("monto")
          .HasColumnType("decimal")
          .HasPrecision(12, 2);

      builder.Property(x => x.Deuda)
          .HasColumnName("deuda")
          .HasColumnType("decimal")
          .HasPrecision(12, 2);

      builder.Property(x => x.Fecha)
          .HasColumnName("fecha")
          .HasColumnType("datetime");

      builder.Property(x => x.TipoReserva)
          .HasColumnName("tipoReserva")
          .HasMaxLength(6);


      /* builder.Property(x => x.ClienteId)
           .HasColumnName("clienteId");

       builder.Property(x => x.VueloId)
           .HasColumnName("vueloId");
      */


    }
  }
}
