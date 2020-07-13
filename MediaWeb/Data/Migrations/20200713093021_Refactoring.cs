using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWeb.Data.Migrations
{
    public partial class Refactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_AspNetUsers_MediaWebUserId",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicList_AspNetUsers_MediaWebUserId",
                table: "MusicList");

            migrationBuilder.DropForeignKey(
                name: "FK_PodCasts_AspNetUsers_MediaWebUserId",
                table: "PodCasts");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_AspNetUsers_MediaWebUserId",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Series_MediaWebUserId",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_PodCasts_MediaWebUserId",
                table: "PodCasts");

            migrationBuilder.DropIndex(
                name: "IX_MusicList_MediaWebUserId",
                table: "MusicList");

            migrationBuilder.DropIndex(
                name: "IX_Films_MediaWebUserId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "MediaWebUserId",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "MediaWebUserId",
                table: "PodCasts");

            migrationBuilder.DropColumn(
                name: "MediaWebUserId",
                table: "MusicList");

            migrationBuilder.DropColumn(
                name: "MediaWebUserId",
                table: "Films");

            migrationBuilder.CreateTable(
                name: "UserFilms",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    FilmId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFilms", x => new { x.UserId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_UserFilms_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFilms_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMusicList",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    MusicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMusicList", x => new { x.UserId, x.MusicId });
                    table.ForeignKey(
                        name: "FK_UserMusicList_MusicList_MusicId",
                        column: x => x.MusicId,
                        principalTable: "MusicList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMusicList_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPodCasts",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    PodCastId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPodCasts", x => new { x.UserId, x.PodCastId });
                    table.ForeignKey(
                        name: "FK_UserPodCasts_PodCasts_PodCastId",
                        column: x => x.PodCastId,
                        principalTable: "PodCasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPodCasts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSeries",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    SerieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSeries", x => new { x.UserId, x.SerieId });
                    table.ForeignKey(
                        name: "FK_UserSeries_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSeries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFilms_FilmId",
                table: "UserFilms",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMusicList_MusicId",
                table: "UserMusicList",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPodCasts_PodCastId",
                table: "UserPodCasts",
                column: "PodCastId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSeries_SerieId",
                table: "UserSeries",
                column: "SerieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFilms");

            migrationBuilder.DropTable(
                name: "UserMusicList");

            migrationBuilder.DropTable(
                name: "UserPodCasts");

            migrationBuilder.DropTable(
                name: "UserSeries");

            migrationBuilder.AddColumn<string>(
                name: "MediaWebUserId",
                table: "Series",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediaWebUserId",
                table: "PodCasts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediaWebUserId",
                table: "MusicList",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediaWebUserId",
                table: "Films",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Series_MediaWebUserId",
                table: "Series",
                column: "MediaWebUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PodCasts_MediaWebUserId",
                table: "PodCasts",
                column: "MediaWebUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicList_MediaWebUserId",
                table: "MusicList",
                column: "MediaWebUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_MediaWebUserId",
                table: "Films",
                column: "MediaWebUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_AspNetUsers_MediaWebUserId",
                table: "Films",
                column: "MediaWebUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicList_AspNetUsers_MediaWebUserId",
                table: "MusicList",
                column: "MediaWebUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PodCasts_AspNetUsers_MediaWebUserId",
                table: "PodCasts",
                column: "MediaWebUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Series_AspNetUsers_MediaWebUserId",
                table: "Series",
                column: "MediaWebUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
