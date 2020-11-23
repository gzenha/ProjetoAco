using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Orcamento.API.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    Iditem = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 80, nullable: false),
                    Flag = table.Column<string>(maxLength: 300, nullable: false),
                    valoritem = table.Column<decimal>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.Iditem);
                });

            migrationBuilder.CreateTable(
                name: "tborcamentos",
                columns: table => new
                {
                    idorcamento = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dt_orcamento = table.Column<DateTime>(maxLength: 80, nullable: false),
                    dt_alteracao = table.Column<DateTime>(nullable: false),
                    usu_orcamento = table.Column<string>(nullable: true),
                    usu_alteracao = table.Column<string>(nullable: false),
                    valor_total = table.Column<decimal>(nullable: false),
                    valor_descont = table.Column<decimal>(nullable: false),
                    sit_orcamento = table.Column<string>(nullable: true),
                    clienteIdCliente = table.Column<int>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tborcamentos", x => x.idorcamento);
                    table.ForeignKey(
                        name: "FK_tborcamentos_Clientes_clienteIdCliente",
                        column: x => x.clienteIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "listaItems",
                columns: table => new
                {
                    idlistaitem = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    valor = table.Column<decimal>(maxLength: 80, nullable: false),
                    orcamentoidorcamento = table.Column<int>(nullable: true),
                    idorcamento = table.Column<int>(nullable: false),
                    itemIditem = table.Column<int>(nullable: true),
                    iditem = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listaItems", x => x.idlistaitem);
                    table.ForeignKey(
                        name: "FK_listaItems_items_itemIditem",
                        column: x => x.itemIditem,
                        principalTable: "items",
                        principalColumn: "Iditem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_listaItems_tborcamentos_orcamentoidorcamento",
                        column: x => x.orcamentoidorcamento,
                        principalTable: "tborcamentos",
                        principalColumn: "idorcamento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_listaItems_itemIditem",
                table: "listaItems",
                column: "itemIditem");

            migrationBuilder.CreateIndex(
                name: "IX_listaItems_orcamentoidorcamento",
                table: "listaItems",
                column: "orcamentoidorcamento");

            migrationBuilder.CreateIndex(
                name: "IX_tborcamentos_clienteIdCliente",
                table: "tborcamentos",
                column: "clienteIdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "listaItems");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "tborcamentos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
