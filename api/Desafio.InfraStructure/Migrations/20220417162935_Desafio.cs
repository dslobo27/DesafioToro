using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Senha = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
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
                    { new Guid("488cfa78-2506-4f1a-99bb-7fc2c5749225"), "PETR4", 5, 28.44m },
                    { new Guid("1e2d11b0-a3f6-4e55-a94d-c918abbf0c8b"), "MGLU3", 4, 25.91m },
                    { new Guid("f039ac06-a8be-4572-9bb2-c9878a14df1c"), "VVAR3", 3, 25.91m },
                    { new Guid("eeeca5a2-5947-4def-8e10-fce4e7e8335b"), "SANB11", 2, 40.77m },
                    { new Guid("88abab1a-6e03-4f95-b274-7f1aa18fae93"), "TORO4", 1, 115.98m }
                });

            migrationBuilder.InsertData(
                table: "ContasCorrentes",
                columns: new[] { "Id", "Saldo" },
                values: new object[] { new Guid("ca6331b4-52d4-4ee7-9970-7be33fa76628"), 100m });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CPF", "ContaCorrenteId", "Nome", "Senha" },
                values: new object[] { new Guid("19caa746-6d78-4bcd-a2a2-227750bcb236"), "17811768097", new Guid("ca6331b4-52d4-4ee7-9970-7be33fa76628"), "Cesar Tralli", "123" });

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
