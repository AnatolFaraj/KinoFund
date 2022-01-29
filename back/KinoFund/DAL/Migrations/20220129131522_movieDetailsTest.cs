using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class movieDetailsTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MovieDetails",
                columns: new[] { "MovieID", "Country", "Description", "PEGI", "Picture", "ReleaseDate" },
                values: new object[] { 1L, "USA", "someDescription", "18+", "someJPG", new DateTime(1994, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "MovieDetails",
                columns: new[] { "MovieID", "Country", "Description", "PEGI", "Picture", "ReleaseDate" },
                values: new object[] { 2L, "USA", "someDescription", "16+", "SomeJPG", new DateTime(1980, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieDetails",
                keyColumn: "MovieID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "MovieDetails",
                keyColumn: "MovieID",
                keyValue: 2L);
        }
    }
}
