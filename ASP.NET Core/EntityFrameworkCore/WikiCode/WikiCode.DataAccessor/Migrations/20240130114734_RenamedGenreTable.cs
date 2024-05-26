using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiCode.DataAccessor.Migrations
{
    /// <inheritdoc />
    public partial class RenamedGenreTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "tbl_genre");

            migrationBuilder.RenameColumn(
                name: "GenreName",
                table: "tbl_genre",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_genre",
                table: "tbl_genre",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_genre",
                table: "tbl_genre");

            migrationBuilder.RenameTable(
                name: "tbl_genre",
                newName: "Genres");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Genres",
                newName: "GenreName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "GenreId");
        }
    }
}
