using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DAL.Migrations
{
    public partial class commentsTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "UserName", "DateOfBirth", "Type" },
                values: new object[] {1L, "Mike1994", new DateTime(1994, 7, 24), 1 });

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
                columns: new[] { "CommentID", "UserID", "MovieID", "Date",  "Text"},
                values: new object[] { 1L, 1L, 10L, new DateTime(2022, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some strange movie. Didn't like it." });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "UserID", "MovieID", "Date", "Text", "RefersToCommentID" },
                values: new object[] { 2L, 2L, 10L, new DateTime(2022, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "You are strange!", 1L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 2L);
        }
    }
}
