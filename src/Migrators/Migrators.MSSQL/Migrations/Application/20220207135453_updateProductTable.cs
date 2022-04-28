using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application;

public partial class updateProductTable : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "AletQuantity",
            table: "Products");

        migrationBuilder.AddColumn<decimal>(
            name: "AlertQuantity",
            table: "Products",
            type: "decimal(18,2)",
            nullable: false,
            defaultValue: 0m);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "AlertQuantity",
            table: "Products");

        migrationBuilder.AddColumn<int>(
            name: "AletQuantity",
            table: "Products",
            type: "int",
            nullable: false,
            defaultValue: 0);
    }
}
