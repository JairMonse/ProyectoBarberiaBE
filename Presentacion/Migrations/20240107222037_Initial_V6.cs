using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presentacion.Migrations
{
    /// <inheritdoc />
    public partial class Initial_V6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CitasCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaCita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombreBarbero = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    nombreCliente = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    telefono = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    correoE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    tipoServicio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitasCliente", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitasCliente");
        }
    }
}
