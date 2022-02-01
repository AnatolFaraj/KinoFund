using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class TablesTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionMovie");

            migrationBuilder.CreateTable(
                name: "CollectionModelMovieModel",
                columns: table => new
                {
                    CollectionsCollectionId = table.Column<long>(type: "bigint", nullable: false),
                    MoviesMovieId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionModelMovieModel", x => new { x.CollectionsCollectionId, x.MoviesMovieId });
                    table.ForeignKey(
                        name: "FK_CollectionModelMovieModel_Collections_CollectionsCollectionId",
                        column: x => x.CollectionsCollectionId,
                        principalTable: "Collections",
                        principalColumn: "CollectionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionModelMovieModel_Movies_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionModelMovieModel_MoviesMovieId",
                table: "CollectionModelMovieModel",
                column: "MoviesMovieId");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionModelMovieModel");

            migrationBuilder.CreateTable(
                name: "CollectionMovie",
                columns: table => new
                {
                    CollectionsCollectionId = table.Column<long>(type: "bigint", nullable: false),
                    MoviesMovieId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionMovie", x => new { x.CollectionsCollectionId, x.MoviesMovieId });
                    table.ForeignKey(
                        name: "FK_CollectionMovie_Collections_CollectionsCollectionId",
                        column: x => x.CollectionsCollectionId,
                        principalTable: "Collections",
                        principalColumn: "CollectionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionMovie_Movies_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionMovie_MoviesMovieId",
                table: "CollectionMovie",
                column: "MoviesMovieId");
        }
    }
}
