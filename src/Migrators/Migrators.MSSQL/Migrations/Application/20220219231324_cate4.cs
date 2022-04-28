using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application;

public partial class cate4 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateIndex(
            name: "IX_Products_SubCategoryId",
            table: "Products",
            column: "SubCategoryId");

        migrationBuilder.AddForeignKey(
            name: "FK_Products_Categories_SubCategoryId",
            table: "Products",
            column: "SubCategoryId",
            principalTable: "Categories",
            principalColumn: "Id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Products_Categories_SubCategoryId",
            table: "Products");

        migrationBuilder.DropIndex(
            name: "IX_Products_SubCategoryId",
            table: "Products");
    }
}
