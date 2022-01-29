using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class movieTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieID", "CategoryID", "Title" },
                values: new object[] { 1L, 1L, "Pulp Fiction" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieID", "CategoryID", "Title" },
                values: new object[] { 2L, 2L, "Friday the 13th" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 2L);
        }
    }
}
