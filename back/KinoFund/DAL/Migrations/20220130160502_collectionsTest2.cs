using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class collectionsTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "CollectionMovie",
               columns: new[] { "CollectionsCollectionId", "MoviesMovieId"},
               values: new object[] { 1, 9 });

            migrationBuilder.InsertData(
               table: "CollectionMovie",
               columns: new[] { "CollectionsCollectionId", "MoviesMovieId" },
               values: new object[] { 1, 10 });

            migrationBuilder.InsertData(
               table: "CollectionMovie",
               columns: new[] { "CollectionsCollectionId", "MoviesMovieId" },
               values: new object[] { 1, 11 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
               table: "CollectionMovie",
               keyColumn: "CollectionsCollectionId",
               keyValue: 1L);
        }
    }
}
