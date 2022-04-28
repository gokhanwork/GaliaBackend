using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    public partial class cate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Categories",
                newName: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryId",
                table: "Categories",
                newName: "ParentId");
        }
    }
}
