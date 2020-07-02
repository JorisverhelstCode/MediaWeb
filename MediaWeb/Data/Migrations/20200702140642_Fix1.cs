using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWeb.Data.Migrations
{
    public partial class Fix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Genre_GenreId",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicList_Genre_GenreId",
                table: "MusicList");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_MusicList_GenreId",
                table: "MusicList");

            migrationBuilder.DropIndex(
                name: "IX_Films_GenreId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "MusicList");

            migrationBuilder.AddColumn<string>(
                name: "MediaWebUserId",
                table: "Series",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediaWebUserId",
                table: "PodCasts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "MusicList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediaWebUserId",
                table: "MusicList",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayListId",
                table: "MusicList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Films",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediaWebUserId",
                table: "Films",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlayList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MediaWebUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayList_AspNetUsers_MediaWebUserId",
                        column: x => x.MediaWebUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_MusicList_PlayListId",
                table: "MusicList",
                column: "PlayListId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_MediaWebUserId",
                table: "Films",
                column: "MediaWebUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayList_MediaWebUserId",
                table: "PlayList",
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
                name: "FK_MusicList_PlayList_PlayListId",
                table: "MusicList",
                column: "PlayListId",
                principalTable: "PlayList",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_AspNetUsers_MediaWebUserId",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicList_AspNetUsers_MediaWebUserId",
                table: "MusicList");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicList_PlayList_PlayListId",
                table: "MusicList");

            migrationBuilder.DropForeignKey(
                name: "FK_PodCasts_AspNetUsers_MediaWebUserId",
                table: "PodCasts");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_AspNetUsers_MediaWebUserId",
                table: "Series");

            migrationBuilder.DropTable(
                name: "PlayList");

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
                name: "IX_MusicList_PlayListId",
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
                name: "Genre",
                table: "MusicList");

            migrationBuilder.DropColumn(
                name: "MediaWebUserId",
                table: "MusicList");

            migrationBuilder.DropColumn(
                name: "PlayListId",
                table: "MusicList");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "MediaWebUserId",
                table: "Films");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "MusicList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicList_GenreId",
                table: "MusicList",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_GenreId",
                table: "Films",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Genre_GenreId",
                table: "Films",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicList_Genre_GenreId",
                table: "MusicList",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
