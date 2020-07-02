using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWeb.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Series",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "PodCasts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "MusicList",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "MusicList",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Films",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Films",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Films",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ReleaseDate",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "PodCasts");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "MusicList");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "MusicList");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Films");
        }
    }
}
