using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Alura.Loja.Testes.ConsoleApp.Migrations
{
    public partial class Promocao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "promocoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataFim = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },//esta sendo criado a tabela de promocoes com os atributos da classe

                constraints: table =>
                {
                    table.PrimaryKey("PK_promocoes", x => x.Id);
                });

            migrationBuilder.CreateTable( // criacao da tabela de join
                name: "PromocaoProduto", //dizendo que essa duas colunas fazem parte da chave primaria
                columns: table => new
                {
                    PromocaoId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromocaoProduto", x => new { x.PromocaoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_PromocaoProduto_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos", //esta apontando para o id de produtos
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade); // se for apagado um produton tambem ser apagado em cascata os registros nessa tabela
                    table.ForeignKey(
                        name: "FK_PromocaoProduto_promocoes_PromocaoId",
                        column: x => x.PromocaoId,
                        principalTable: "promocoes", //esta apontando para o id de promocoes
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromocaoProduto_ProdutoId",
                table: "PromocaoProduto",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromocaoProduto");

            migrationBuilder.DropTable(
                name: "promocoes");
        }
    }
}
