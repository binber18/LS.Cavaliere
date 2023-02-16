using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LS.Cavaliere.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateToTitleImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Dogs_DogId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_DogId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "DogId",
                table: "Files");

            migrationBuilder.AddColumn<string>(
                name: "TitleImage",
                table: "Dogs",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleImage",
                table: "Dogs");

            migrationBuilder.AddColumn<Guid>(
                name: "DogId",
                table: "Files",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_DogId",
                table: "Files",
                column: "DogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Dogs_DogId",
                table: "Files",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id");
        }
    }
}
