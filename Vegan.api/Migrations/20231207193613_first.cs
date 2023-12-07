using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vegan.api.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    idfornecedor = table.Column<int>(type: "int", nullable: false, comment: "Fornecedor IDFornecedor as a primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Fornecedor nome"),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Fornecedor email"),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Fornecedor phone number")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.idfornecedor);
                });

            migrationBuilder.CreateTable(
                name: "PratoRestaurantes",
                columns: table => new
                {
                    idprato = table.Column<int>(type: "int", nullable: false, comment: "Prato IDPrato as a primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRes = table.Column<int>(type: "int", nullable: false),
                    nomeprato = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Prato nome"),
                    descricaoprato = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Descricao do prato"),
                    PrecoPrato = table.Column<int>(type: "int", nullable: false, comment: "Preco do prato")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PratoRestaurantes", x => x.idprato);
                });

            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    idres = table.Column<int>(type: "int", nullable: false, comment: "Restaurante IDRestaurante as a primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFornecedor = table.Column<int>(type: "int", nullable: false),
                    nomeres = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Restaurante nome")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.idres);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    idprod = table.Column<int>(type: "int", nullable: false, comment: "Produto IDProd as a primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFornecedor = table.Column<int>(type: "int", nullable: false),
                    nomeprod = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Produto nome"),
                    descricaoprod = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Descricao do produto"),
                    PrecoProd = table.Column<int>(type: "int", nullable: false, comment: "Preco do produto")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.idprod);
                    table.ForeignKey(
                        name: "FK_Produtos_Fornecedores_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "Fornecedores",
                        principalColumn: "idfornecedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestauranteFornecedor",
                columns: table => new
                {
                    FornecedoresIdFornecedor = table.Column<int>(type: "int", nullable: false),
                    RestaurantesIdRes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestauranteFornecedor", x => new { x.FornecedoresIdFornecedor, x.RestaurantesIdRes });
                    table.ForeignKey(
                        name: "FK_RestauranteFornecedor_Fornecedores_FornecedoresIdFornecedor",
                        column: x => x.FornecedoresIdFornecedor,
                        principalTable: "Fornecedores",
                        principalColumn: "idfornecedor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestauranteFornecedor_Restaurantes_RestaurantesIdRes",
                        column: x => x.RestaurantesIdRes,
                        principalTable: "Restaurantes",
                        principalColumn: "idres",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantePratoAssociacao",
                columns: table => new
                {
                    PratosRestaurantesIdPrato = table.Column<int>(type: "int", nullable: false),
                    RestaurantesIdRes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantePratoAssociacao", x => new { x.PratosRestaurantesIdPrato, x.RestaurantesIdRes });
                    table.ForeignKey(
                        name: "FK_RestaurantePratoAssociacao_PratoRestaurantes_PratosRestaurantesIdPrato",
                        column: x => x.PratosRestaurantesIdPrato,
                        principalTable: "PratoRestaurantes",
                        principalColumn: "idprato",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantePratoAssociacao_Restaurantes_RestaurantesIdRes",
                        column: x => x.RestaurantesIdRes,
                        principalTable: "Restaurantes",
                        principalColumn: "idres",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "idfornecedor", "email", "nome", "phone" },
                values: new object[] { 1, "jaojoao@gmail.com", "Jão João", "40028922" });

            migrationBuilder.InsertData(
                table: "PratoRestaurantes",
                columns: new[] { "idprato", "descricaoprato", "IdRes", "nomeprato", "PrecoPrato" },
                values: new object[] { 1, "Lasanha vegana de aabobrinha, cogumelos e espinafre", 1, "Lasanha de abobrinha vegana", 32 });

            migrationBuilder.InsertData(
                table: "Restaurantes",
                columns: new[] { "idres", "IdFornecedor", "nomeres" },
                values: new object[] { 1, 1, "Brown kitchen" });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "idprod", "descricaoprod", "IdFornecedor", "nomeprod", "PrecoProd" },
                values: new object[] { 1, "Shampoo com ingredientes naturais. Cruelty-free e vegano", 1, "Shampoo de menta vegano", 25 });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdFornecedor",
                table: "Produtos",
                column: "IdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_RestauranteFornecedor_RestaurantesIdRes",
                table: "RestauranteFornecedor",
                column: "RestaurantesIdRes");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantePratoAssociacao_RestaurantesIdRes",
                table: "RestaurantePratoAssociacao",
                column: "RestaurantesIdRes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "RestauranteFornecedor");

            migrationBuilder.DropTable(
                name: "RestaurantePratoAssociacao");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "PratoRestaurantes");

            migrationBuilder.DropTable(
                name: "Restaurantes");
        }
    }
}
