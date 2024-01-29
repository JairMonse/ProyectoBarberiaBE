﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presentacion.Migrations
{
    /// <inheritdoc />
    public partial class Initial_V7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreProducto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    cantidadProducto = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<float>(type: "real", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventarios");
        }
    }
}
