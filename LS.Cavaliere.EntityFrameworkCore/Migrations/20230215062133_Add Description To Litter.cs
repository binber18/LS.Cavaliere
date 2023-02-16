using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LS.Cavaliere.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToLitter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puppy_Litters_LitterId",
                table: "Puppy");

            migrationBuilder.AlterColumn<Guid>(
                name: "LitterId",
                table: "Puppy",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Litters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Puppy_Litters_LitterId",
                table: "Puppy",
                column: "LitterId",
                principalTable: "Litters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puppy_Litters_LitterId",
                table: "Puppy");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Litters");

            migrationBuilder.AlterColumn<Guid>(
                name: "LitterId",
                table: "Puppy",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Puppy_Litters_LitterId",
                table: "Puppy",
                column: "LitterId",
                principalTable: "Litters",
                principalColumn: "Id");
        }
    }
}
