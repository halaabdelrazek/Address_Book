using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAL.Migrations
{
    public partial class _4Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Contacts",
                newName: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Contacts",
                newName: "Name");
        }
    }
}
