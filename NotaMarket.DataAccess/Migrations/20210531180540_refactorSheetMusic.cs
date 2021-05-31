using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotaMarket.DataAccess.Migrations
{
    public partial class refactorSheetMusic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SheetMusics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SheetMusics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "SheetMusics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "SheetMusics",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SheetMusics");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SheetMusics");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "SheetMusics");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "SheetMusics");
        }
    }
}
