using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas.Infraestructure.EntityFramework.ReadModel;

namespace Reservas.Infraestructura.EntityFramework.Config.ReadConfig {
  public class ProductoReadConfig : IEntityTypeConfiguration<ProductoReadModel> {
    public void Configure(EntityTypeBuilder<ProductoReadModel> builder) {
      builder.ToTable("Producto");
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Nombre)
          .HasMaxLength(500)
          .HasColumnName("nombre");


      builder.Property(x => x.PrecioVenta)
          .HasColumnName("precioVenta")
          .HasColumnType("decimal")
          .HasPrecision(12, 2);

      builder.Property(x => x.StockActual)
          .HasColumnName("stockActual");

    }
  }
}
