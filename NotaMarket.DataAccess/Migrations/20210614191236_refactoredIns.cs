using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotaMarket.DataAccess.Migrations
{
    public partial class refactoredIns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Instruments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Instruments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Instruments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "Instruments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Instruments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "Instruments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UploadedBy",
                table: "Instruments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "UploadedBy",
                table: "Instruments");
        }
    }
}
