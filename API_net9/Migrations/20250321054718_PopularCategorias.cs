﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_net9.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Categorias (Nome,ImagemUrl) Values ('Bebidas','bebidas.jpg')");
            migrationBuilder.Sql("insert into Categorias (Nome,ImagemUrl) Values ('Lanches','lanches.jpg')");
            migrationBuilder.Sql("insert into Categorias (Nome,ImagemUrl) Values ('Sobremesas','sobremesas.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categorias");
        }
    }
}
