using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class storedProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[spGetTotalMovieRating]

                        @MovieId BIGINT,
						@TotalRating FLOAT output
                        AS
                        BEGIN
						set nocount on;
	                        SELECT
	                        @TotalRating = SUM(Value) / COUNT(Value)
	                        FROM dbo.Ratings
	                        WHERE MovieID = @MovieId
							return;
							
                        END";



            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE spGetTotalMovieRating";
            migrationBuilder.Sql(sp);
        }
    }
}
