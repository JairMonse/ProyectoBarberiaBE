using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presentacion.Migrations
{
    /// <inheritdoc />
    public partial class Initial_V8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaRegistro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombreCliente = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    nombreProducto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    metodoPago = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ventas");
        }
    }
}
