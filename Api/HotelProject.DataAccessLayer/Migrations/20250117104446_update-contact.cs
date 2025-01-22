using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class updatecontact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Contacts",
                newName: "ContactName");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Contacts",
                newName: "ContactMessage");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "Contacts",
                newName: "ContactMail");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Contacts",
                newName: "ContactDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Contacts",
                newName: "ContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactName",
                table: "Contacts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ContactMessage",
                table: "Contacts",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "ContactMail",
                table: "Contacts",
                newName: "Mail");

            migrationBuilder.RenameColumn(
                name: "ContactDate",
                table: "Contacts",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "Contacts",
                newName: "Id");
        }
    }
}
