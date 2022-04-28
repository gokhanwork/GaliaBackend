﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application;

public partial class updateCategory : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Categories_Categories_ParentId",
            table: "Categories");

        migrationBuilder.DropIndex(
            name: "IX_Categories_ParentId",
            table: "Categories");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateIndex(
            name: "IX_Categories_ParentId",
            table: "Categories",
            column: "ParentId");

        migrationBuilder.AddForeignKey(
            name: "FK_Categories_Categories_ParentId",
            table: "Categories",
            column: "ParentId",
            principalTable: "Categories",
            principalColumn: "Id");
    }
}
