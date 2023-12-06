using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vegan.api.Migrations
{
    /// <inheritdoc />
    public partial class Primeira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pratorestaurante",
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
                    table.PrimaryKey("PK_pratorestaurante", x => x.idprato);
                });

            migrationBuilder.CreateTable(
                name: "restaurante",
                columns: table => new
                {
                    idres = table.Column<int>(type: "int", nullable: false, comment: "Restaurante IDRestaurante as a primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFornecedor = table.Column<int>(type: "int", nullable: false),
                    nomeres = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Restaurante nome"),
                    descricaores = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Descricao do restaurante")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurante", x => x.idres);
                });

            migrationBuilder.CreateTable(
                name: "PratosRestaurantes",
                columns: table => new
                {
                    PratosRestaurantesIdPrato = table.Column<int>(type: "int", nullable: false),
                    RestaurantesIdRes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PratosRestaurantes", x => new { x.PratosRestaurantesIdPrato, x.RestaurantesIdRes });
                    table.ForeignKey(
                        name: "FK_PratosRestaurantes_pratorestaurante_PratosRestaurantesIdPrato",
                        column: x => x.PratosRestaurantesIdPrato,
                        principalTable: "pratorestaurante",
                        principalColumn: "idprato",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PratosRestaurantes_restaurante_RestaurantesIdRes",
                        column: x => x.RestaurantesIdRes,
                        principalTable: "restaurante",
                        principalColumn: "idres",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fornecedor",
                columns: table => new
                {
                    idfornecedor = table.Column<int>(type: "int", nullable: false, comment: "Fornecedor IDFornecedor as a primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Fornecedor nome"),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Fornecedor email"),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Fornecedor phone number"),
                    ProdutoIdProd = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fornecedor", x => x.idfornecedor);
                });

            migrationBuilder.CreateTable(
                name: "produto",
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
                    table.PrimaryKey("PK_produto", x => x.idprod);
                    table.ForeignKey(
                        name: "FK_produto_fornecedor_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "fornecedor",
                        principalColumn: "idfornecedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestauranteFornecedor",
                columns: table => new
                {
                    FornecedorsIdFornecedor = table.Column<int>(type: "int", nullable: false),
                    RestaurantesIdRes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestauranteFornecedor", x => new { x.FornecedorsIdFornecedor, x.RestaurantesIdRes });
                    table.ForeignKey(
                        name: "FK_RestauranteFornecedor_fornecedor_FornecedorsIdFornecedor",
                        column: x => x.FornecedorsIdFornecedor,
                        principalTable: "fornecedor",
                        principalColumn: "idfornecedor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestauranteFornecedor_restaurante_RestaurantesIdRes",
                        column: x => x.RestaurantesIdRes,
                        principalTable: "restaurante",
                        principalColumn: "idres",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "fornecedor",
                columns: new[] { "idfornecedor", "email", "nome", "phone", "ProdutoIdProd" },
                values: new object[] { 1, "jaojoao@gmail.com", "Jão João", "40028922", null });

            migrationBuilder.InsertData(
                table: "pratorestaurante",
                columns: new[] { "idprato", "descricaoprato", "IdRes", "nomeprato", "PrecoPrato" },
                values: new object[] { 1, "Lasanha vegana de aabobrinha, cogumelos e espinafre", 1, "Lasanha de abobrinha vegana", 32 });

            migrationBuilder.InsertData(
                table: "restaurante",
                columns: new[] { "idres", "descricaores", "IdFornecedor", "nomeres" },
                values: new object[] { 1, "Um dos melhores restaurantes veganos de sp. Localizado na Vila Madalena, Rua papap, n° tal", 1, "Brown kitchen" });

            migrationBuilder.InsertData(
                table: "produto",
                columns: new[] { "idprod", "descricaoprod", "IdFornecedor", "nomeprod", "PrecoProd" },
                values: new object[] { 1, "Shampoo com ingredientes naturais. Cruelty-free e vegano", 1, "Shampoo de menta vegano", 25 });

            migrationBuilder.CreateIndex(
                name: "IX_fornecedor_ProdutoIdProd",
                table: "fornecedor",
                column: "ProdutoIdProd");

            migrationBuilder.CreateIndex(
                name: "IX_PratosRestaurantes_RestaurantesIdRes",
                table: "PratosRestaurantes",
                column: "RestaurantesIdRes");

            migrationBuilder.CreateIndex(
                name: "IX_produto_IdFornecedor",
                table: "produto",
                column: "IdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_RestauranteFornecedor_RestaurantesIdRes",
                table: "RestauranteFornecedor",
                column: "RestaurantesIdRes");

            migrationBuilder.AddForeignKey(
                name: "FK_fornecedor_produto_ProdutoIdProd",
                table: "fornecedor",
                column: "ProdutoIdProd",
                principalTable: "produto",
                principalColumn: "idprod");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fornecedor_produto_ProdutoIdProd",
                table: "fornecedor");

            migrationBuilder.DropTable(
                name: "PratosRestaurantes");

            migrationBuilder.DropTable(
                name: "RestauranteFornecedor");

            migrationBuilder.DropTable(
                name: "pratorestaurante");

            migrationBuilder.DropTable(
                name: "restaurante");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "fornecedor");
        }
    }
}
