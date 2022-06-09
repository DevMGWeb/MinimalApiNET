using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectef.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("4b00cae4-b7d2-44fa-a816-a26412be5002"), null, "Actividades Personales", 10 },
                    { new Guid("4b00cae4-b7d2-44fa-a816-a26412be5003"), null, "Actividades Pendientes 2", 30 },
                    { new Guid("4b00cae4-b7d2-44fa-a816-a26412be5004"), null, "Actividades Personales 2", 40 },
                    { new Guid("4b00cae4-b7d2-44fa-a816-a26412be509b"), null, "Actividades Pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("4b00cae4-b7d2-44fa-a816-a26412be5011"), new Guid("4b00cae4-b7d2-44fa-a816-a26412be509b"), null, new DateTime(2022, 5, 27, 17, 43, 29, 89, DateTimeKind.Local).AddTicks(4391), 1, "Pago de servicios publicos" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("4b00cae4-b7d2-44fa-a816-a26412be5012"), new Guid("4b00cae4-b7d2-44fa-a816-a26412be5002"), null, new DateTime(2022, 5, 27, 17, 43, 29, 89, DateTimeKind.Local).AddTicks(4451), 0, "Terminar de ver pelicula en netflix" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("4b00cae4-b7d2-44fa-a816-a26412be5003"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("4b00cae4-b7d2-44fa-a816-a26412be5004"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("4b00cae4-b7d2-44fa-a816-a26412be5011"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("4b00cae4-b7d2-44fa-a816-a26412be5012"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("4b00cae4-b7d2-44fa-a816-a26412be5002"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("4b00cae4-b7d2-44fa-a816-a26412be509b"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
