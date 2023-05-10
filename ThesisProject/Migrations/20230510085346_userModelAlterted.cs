using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThesisProject.Migrations
{
    /// <inheritdoc />
    public partial class userModelAlterted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fullName",
                table: "users",
                newName: "lastname");

            migrationBuilder.AddColumn<string>(
                name: "firstname",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstname",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "users",
                newName: "fullName");
        }
    }
}
