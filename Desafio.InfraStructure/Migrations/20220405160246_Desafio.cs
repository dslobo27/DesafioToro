using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.InfraStructure.Migrations
{
    public partial class Desafio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContasCorrentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasCorrentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContaCorrenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_ContasCorrentes_ContaCorrenteId",
                        column: x => x.ContaCorrenteId,
                        principalTable: "ContasCorrentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ativos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    QuantidadeNegociados = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ativos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ativos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Ativos",
                columns: new[] { "Id", "Codigo", "QuantidadeNegociados", "UsuarioId", "Valor" },
                values: new object[,]
                {
                    { new Guid("8e662be8-8664-4d54-b9ba-734d06c0d4b7"), "PETR4", 5, null, 28.44m },
                    { new Guid("4c45c87c-dfdf-41e6-a580-051c392f0458"), "MGLU3", 4, null, 25.91m },
                    { new Guid("4cd6fe4d-c817-413c-8c3a-6c87f4635757"), "VVAR3", 3, null, 25.91m },
                    { new Guid("fd0bbe63-640e-4854-9389-7e8aa321832f"), "SANB11", 2, null, 40.77m },
                    { new Guid("c4d73ebe-3c33-402e-ad67-233bb7d20051"), "TORO4", 1, null, 115.98m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ativos_UsuarioId",
                table: "Ativos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ContaCorrenteId",
                table: "Usuarios",
                column: "ContaCorrenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ativos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "ContasCorrentes");
        }
    }
}
