using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotaMarket.DataAccess.Migrations
{
    public partial class fileInstrumentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "InstrumentTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "InstrumentTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "InstrumentTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "InstrumentTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "InstrumentTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "InstrumentTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UploadedBy",
                table: "InstrumentTypes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "InstrumentTypes");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "InstrumentTypes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "InstrumentTypes");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "InstrumentTypes");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "InstrumentTypes");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "InstrumentTypes");

            migrationBuilder.DropColumn(
                name: "UploadedBy",
                table: "InstrumentTypes");
        }
    }
}
