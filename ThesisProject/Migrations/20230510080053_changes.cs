using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThesisProject.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileImage",
                table: "users",
                newName: "profileImage");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "users",
                newName: "fullName");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "SongName",
                table: "songs",
                newName: "songName");

            migrationBuilder.RenameColumn(
                name: "SongFile",
                table: "songs",
                newName: "songFile");

            migrationBuilder.RenameColumn(
                name: "Mood",
                table: "songs",
                newName: "mood");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "songs",
                newName: "genre");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "songs",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "Artist",
                table: "songs",
                newName: "artist");

            migrationBuilder.RenameColumn(
                name: "SongId",
                table: "songs",
                newName: "songId");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "likes",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "SongId",
                table: "likes",
                newName: "songId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "likes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "history",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "TimesListened",
                table: "history",
                newName: "timesListened");

            migrationBuilder.RenameColumn(
                name: "SongId",
                table: "history",
                newName: "songId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "history",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "profileImage",
                table: "users",
                newName: "ProfileImage");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "fullName",
                table: "users",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "songName",
                table: "songs",
                newName: "SongName");

            migrationBuilder.RenameColumn(
                name: "songFile",
                table: "songs",
                newName: "SongFile");

            migrationBuilder.RenameColumn(
                name: "mood",
                table: "songs",
                newName: "Mood");

            migrationBuilder.RenameColumn(
                name: "genre",
                table: "songs",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "songs",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "artist",
                table: "songs",
                newName: "Artist");

            migrationBuilder.RenameColumn(
                name: "songId",
                table: "songs",
                newName: "SongId");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "likes",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "songId",
                table: "likes",
                newName: "SongId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "likes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "history",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "timesListened",
                table: "history",
                newName: "TimesListened");

            migrationBuilder.RenameColumn(
                name: "songId",
                table: "history",
                newName: "SongId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "history",
                newName: "Id");
        }
    }
}
