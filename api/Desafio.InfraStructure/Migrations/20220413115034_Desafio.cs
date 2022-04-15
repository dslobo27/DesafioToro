using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Desafio.InfraStructure.Migrations
{
    public partial class Desafio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ativos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    QuantidadeNegociados = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ativos", x => x.Id);
                });

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
                name: "AtivosUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtivosUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtivosUsuario_Ativos_AtivoId",
                        column: x => x.AtivoId,
                        principalTable: "Ativos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtivosUsuario_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ativos",
                columns: new[] { "Id", "Codigo", "QuantidadeNegociados", "Valor" },
                values: new object[,]
                {
                    { new Guid("f167a925-df66-443e-a3d7-40091a991b31"), "PETR4", 5, 28.44m },
                    { new Guid("7438311b-37ca-488e-bbf9-bb7af8a670ab"), "MGLU3", 4, 25.91m },
                    { new Guid("be6fa5e2-3a2d-4685-9586-253f1ef7e31f"), "VVAR3", 3, 25.91m },
                    { new Guid("ab5c2ecc-e451-4687-97d7-e5f5463b7d09"), "SANB11", 2, 40.77m },
                    { new Guid("5c3ee54f-1b6a-4e49-a2b6-fbca14ae1794"), "TORO4", 1, 115.98m }
                });

            migrationBuilder.InsertData(
                table: "ContasCorrentes",
                columns: new[] { "Id", "Saldo" },
                values: new object[] { new Guid("ca6331b4-52d4-4ee7-9970-7be33fa76628"), 100m });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CPF", "ContaCorrenteId", "Nome" },
                values: new object[] { new Guid("4d88d723-7565-4de8-adf8-7d5f43aff5e0"), "17811768097", new Guid("ca6331b4-52d4-4ee7-9970-7be33fa76628"), "Cesar Tralli" });

            migrationBuilder.CreateIndex(
                name: "IX_AtivosUsuario_AtivoId",
                table: "AtivosUsuario",
                column: "AtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_AtivosUsuario_UsuarioId",
                table: "AtivosUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ContaCorrenteId",
                table: "Usuarios",
                column: "ContaCorrenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtivosUsuario");

            migrationBuilder.DropTable(
                name: "Ativos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "ContasCorrentes");
        }
    }
}