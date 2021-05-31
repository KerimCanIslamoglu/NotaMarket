using Microsoft.EntityFrameworkCore.Migrations;

namespace NotaMarket.DataAccess.Migrations
{
    public partial class refactorPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "InstrumentTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Instruments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "InstrumentTypes");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Instruments");
        }
    }
}
