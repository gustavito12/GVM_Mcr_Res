using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservas.Infraestructura.EF.Migrations {
  public partial class InitialStructure : Migration {
    protected override void Up(MigrationBuilder migrationBuilder) {
      migrationBuilder.CreateTable(
          name: "Cliente",
          columns: table => new {
            Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            nombreCompleto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
          },
          constraints: table => {
            table.PrimaryKey("PK_Cliente", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Producto",
          columns: table => new {
            Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
            precioVenta = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
            stockActual = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table => {
            table.PrimaryKey("PK_Producto", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Vuelo",
          columns: table => new {
            Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            cantidad = table.Column<int>(type: "int", nullable: false),
            detalle = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
            precioPasaje = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
          },
          constraints: table => {
            table.PrimaryKey("PK_Vuelo", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Reserva",
          columns: table => new {
            Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            codReserva = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
            estadoReserva = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
            monto = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
            deuda = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
            fecha = table.Column<DateTime>(type: "datetime", nullable: false),
            tipoReserva = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
            ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            VueloId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
          },
          constraints: table => {
            table.PrimaryKey("PK_Reserva", x => x.Id);
            table.ForeignKey(
                      name: "FK_Reserva_Cliente_ClienteId",
                      column: x => x.ClienteId,
                      principalTable: "Cliente",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_Reserva_Vuelo_VueloId",
                      column: x => x.VueloId,
                      principalTable: "Vuelo",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Factura",
          columns: table => new {
            Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            monto = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
            fecha = table.Column<DateTime>(type: "datetime", nullable: false),
            nroFactura = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
            ReservaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
          },
          constraints: table => {
            table.PrimaryKey("PK_Factura", x => x.Id);
            table.ForeignKey(
                      name: "FK_Factura_Reserva_ReservaId",
                      column: x => x.ReservaId,
                      principalTable: "Reserva",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Pago",
          columns: table => new {
            Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            monto = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
            fecha = table.Column<DateTime>(type: "datetime", nullable: false),
            codComprobante = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
            ReservaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
          },
          constraints: table => {
            table.PrimaryKey("PK_Pago", x => x.Id);
            table.ForeignKey(
                      name: "FK_Pago_Reserva_ReservaId",
                      column: x => x.ReservaId,
                      principalTable: "Reserva",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateIndex(
          name: "IX_Factura_ReservaId",
          table: "Factura",
          column: "ReservaId");

      migrationBuilder.CreateIndex(
          name: "IX_Pago_ReservaId",
          table: "Pago",
          column: "ReservaId");

      migrationBuilder.CreateIndex(
          name: "IX_Reserva_ClienteId",
          table: "Reserva",
          column: "ClienteId");

      migrationBuilder.CreateIndex(
          name: "IX_Reserva_VueloId",
          table: "Reserva",
          column: "VueloId");
    }

    protected override void Down(MigrationBuilder migrationBuilder) {
      migrationBuilder.DropTable(
          name: "Factura");

      migrationBuilder.DropTable(
          name: "Pago");

      migrationBuilder.DropTable(
          name: "Producto");

      migrationBuilder.DropTable(
          name: "Reserva");

      migrationBuilder.DropTable(
          name: "Cliente");

      migrationBuilder.DropTable(
          name: "Vuelo");
    }
  }
}
