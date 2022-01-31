using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class collectionsTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "CollectionID", "Name", "UserID", "Type" },
                values: new object[] { 1L, "MyFavourites", 1L, 1 });

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "CollectionID", "Name", "UserID", "Type" },
                values: new object[] { 2L, "MyCollection", 2L, 1 });

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "CollectionID", "Name", "UserID", "Type" },
                values: new object[] { 3L, "BestMoviesEver", 3L, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "CollectionID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "CollectionID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "CollectionID",
                keyValue: 3L);
        }
    }
}
