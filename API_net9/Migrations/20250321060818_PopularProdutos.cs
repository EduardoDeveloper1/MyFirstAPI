using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_net9.Migrations
{
    /// <inheritdoc />
    public partial class PopularProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Produtos (NomeProduto, Descricao, Preco, ImagemUrlProduto, Estoque, DataCadastro, CategoriaId) " +
                "Values ('Coca-Cola zero', 'Refrigerante de cola 350ml', 3.50, 'cocacola.jpg', 50, now(), 1)");

            migrationBuilder.Sql("Insert into Produtos (NomeProduto, Descricao, Preco, ImagemUrlProduto, Estoque, DataCadastro, CategoriaId) " +
                "Values ('Lanche de atum', 'Lanche de atum com maionese', 8.50, 'atum.jpg', 10, now(), 2)");

            migrationBuilder.Sql("Insert into Produtos (NomeProduto, Descricao, Preco, ImagemUrlProduto, Estoque, DataCadastro, CategoriaId) " +
                "Values ('Pudim', 'Pùdim de leite condensado 100g', 5, 'pudim.jpg', 20, now(), 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Produtos");
        }
    }
}
