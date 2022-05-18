using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAL.Migrations
{
    public partial class secondMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressBookUser_Departments_DepartmentId",
                table: "AddressBookUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressBookUser_JobTitles_JobTitleId",
                table: "AddressBookUser");

            migrationBuilder.DropIndex(
                name: "IX_AddressBookUser_DepartmentId",
                table: "AddressBookUser");

            migrationBuilder.DropIndex(
                name: "IX_AddressBookUser_JobTitleId",
                table: "AddressBookUser");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AddressBookUser");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "AddressBookUser");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AddressBookUser");

            migrationBuilder.DropColumn(
                name: "JobTitleId",
                table: "AddressBookUser");

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contact_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contact_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "JobTitleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_DepartmentId",
                table: "Contact",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_JobTitleId",
                table: "Contact",
                column: "JobTitleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "AddressBookUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "AddressBookUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AddressBookUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "JobTitleId",
                table: "AddressBookUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AddressBookUser_DepartmentId",
                table: "AddressBookUser",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressBookUser_JobTitleId",
                table: "AddressBookUser",
                column: "JobTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressBookUser_Departments_DepartmentId",
                table: "AddressBookUser",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressBookUser_JobTitles_JobTitleId",
                table: "AddressBookUser",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "JobTitleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
