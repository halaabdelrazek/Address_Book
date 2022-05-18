using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAL.Migrations
{
    public partial class thirdMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Departments_DepartmentId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_JobTitles_JobTitleId",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts");

            migrationBuilder.RenameColumn(
                name: "DeptmentName",
                table: "Departments",
                newName: "DepartmentName");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_JobTitleId",
                table: "Contacts",
                newName: "IX_Contacts_JobTitleId");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_DepartmentId",
                table: "Contacts",
                newName: "IX_Contacts_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Departments_DepartmentId",
                table: "Contacts",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_JobTitles_JobTitleId",
                table: "Contacts",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "JobTitleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Departments_DepartmentId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_JobTitles_JobTitleId",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contact");

            migrationBuilder.RenameColumn(
                name: "DepartmentName",
                table: "Departments",
                newName: "DeptmentName");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_JobTitleId",
                table: "Contact",
                newName: "IX_Contact_JobTitleId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_DepartmentId",
                table: "Contact",
                newName: "IX_Contact_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Departments_DepartmentId",
                table: "Contact",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_JobTitles_JobTitleId",
                table: "Contact",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "JobTitleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
