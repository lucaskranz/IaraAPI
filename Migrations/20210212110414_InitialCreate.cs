using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IaraAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cotacao",
                columns: table => new
                {
                    CotacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJComprador = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    CNPJFornecedor = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    NumeroCotacao = table.Column<int>(type: "int", nullable: false),
                    DataCotacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEntregaCotacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Observação = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotacao", x => x.CotacaoId);
                });

            migrationBuilder.CreateTable(
                name: "CotacaoItem",
                columns: table => new
                {
                    CotacaoItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroItem = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Quantidade = table.Column<double>(type: "float", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Unidade = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CotacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotacaoItem", x => x.CotacaoItemId);
                    table.ForeignKey(
                        name: "FK_CotacaoItem_Cotacao_CotacaoId",
                        column: x => x.CotacaoId,
                        principalTable: "Cotacao",
                        principalColumn: "CotacaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CotacaoItem_CotacaoId",
                table: "CotacaoItem",
                column: "CotacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CotacaoItem");

            migrationBuilder.DropTable(
                name: "Cotacao");
        }
    }
}
