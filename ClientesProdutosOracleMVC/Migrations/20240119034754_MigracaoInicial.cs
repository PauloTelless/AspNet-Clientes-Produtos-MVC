using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientesProdutosOracleMVC.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    NomeUsuario = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    Contato = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeProduto = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    Categoria = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    PrecoProduto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DescricaoProduto = table.Column<string>(type: "NVARCHAR2(300)", maxLength: 300, nullable: false),
                    ClienteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produtos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ClienteId",
                table: "Produtos",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
