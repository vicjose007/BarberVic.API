using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberVic.API.Migrations
{
    public partial class BarberPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BarberPhoto",
                table: "Barbers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarberPhoto",
                table: "Barbers");
        }
    }
}
