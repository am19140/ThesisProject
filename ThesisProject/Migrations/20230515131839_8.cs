using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThesisProject.Migrations
{
    /// <inheritdoc />
    public partial class _8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "songName",
                table: "songs",
                newName: "songname");

            migrationBuilder.RenameColumn(
                name: "songFile",
                table: "songs",
                newName: "songfile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "songname",
                table: "songs",
                newName: "songName");

            migrationBuilder.RenameColumn(
                name: "songfile",
                table: "songs",
                newName: "songFile");
        }
    }
}
