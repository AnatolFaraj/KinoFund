using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DAL.Migrations
{
    public partial class initTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 1L, "Comedy" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 2L, "Horror" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieID", "CategoryID", "Title" },
                values: new object[] { 1L, 1L, "Pulp Fiction" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieID", "CategoryID", "Title" },
                values: new object[] { 2L, 2L, "Friday the 13th" });

            migrationBuilder.InsertData(
                table: "MovieDetails",
                columns: new[] { "MovieID", "Country", "Description", "PEGI", "Picture", "ReleaseDate" },
                values: new object[] { 1L, "USA", "someDescription", "18+", "someJPG", new DateTime(1994, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "MovieDetails",
                columns: new[] { "MovieID", "Country", "Description", "PEGI", "Picture", "ReleaseDate" },
                values: new object[] { 2L, "USA", "someDescription", "16+", "SomeJPG", new DateTime(1980, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "UserName", "DateOfBirth", "Type" },
                values: new object[] { 1L, "Mike1994", new DateTime(1994, 7, 24), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "UserName", "DateOfBirth", "Type" },
                values: new object[] { 2L, "James007", new DateTime(1999, 2, 23), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "UserName", "DateOfBirth", "Type" },
                values: new object[] { 3L, "SonyBoy", new DateTime(2000, 1, 15), 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "UserID", "MovieID", "Date", "Text" },
                values: new object[] { 1L, 1L, 1L, new DateTime(2022, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some strange movie. Didn't like it." });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "UserID", "MovieID", "Date", "Text", "RefersToCommentID" },
                values: new object[] { 2L, 2L, 1L, new DateTime(2022, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "You are strange!", 1L });

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

            migrationBuilder.InsertData(
               table: "CollectionModelMovieModel",
               columns: new[] { "CollectionsCollectionId", "MoviesMovieId" },
               values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
               table: "CollectionModelMovieModel",
               columns: new[] { "CollectionsCollectionId", "MoviesMovieId" },
               values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
               table: "CollectionModelMovieModel",
               columns: new[] { "CollectionsCollectionId", "MoviesMovieId" },
               values: new object[] { 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 1L);

            

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "MovieDetails",
                keyColumn: "MovieID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "MovieDetails",
                keyColumn: "MovieID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3L);

            

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

            migrationBuilder.DeleteData(
               table: "CollectionModelMovieModel",
               keyColumn: "CollectionsCollectionId",
               keyValue: 1L);
        }
    }
}
