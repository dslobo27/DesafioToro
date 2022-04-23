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
                    AtivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtivosUsuario", x => new { x.AtivoId, x.UsuarioId });
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
                    { new Guid("b0875733-f461-4bc8-bb63-6c9b2534701c"), "PETR4", 5, 28.44m },
                    { new Guid("e622f460-451c-42f1-b64b-5fd5a3dda041"), "MGLU3", 4, 25.91m },
                    { new Guid("76014abf-585a-46f6-b95e-4ff597cd9111"), "VVAR3", 3, 25.91m },
                    { new Guid("6a0064d9-5b8e-4d28-97d5-b3d161e9924a"), "SANB11", 2, 40.77m },
                    { new Guid("9f5f5ebb-8916-4846-b180-fe57a6332a16"), "TORO4", 1, 115.98m }
                });

            migrationBuilder.InsertData(
                table: "ContasCorrentes",
                columns: new[] { "Id", "Saldo" },
                values: new object[] { new Guid("ca6331b4-52d4-4ee7-9970-7be33fa76628"), 100m });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CPF", "ContaCorrenteId", "Nome", "Senha" },
                values: new object[] { new Guid("76c88a58-b592-42fa-8c02-f24a1f47dc35"), "17811768097", new Guid("ca6331b4-52d4-4ee7-9970-7be33fa76628"), "Cesar Tralli", "123" });

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
