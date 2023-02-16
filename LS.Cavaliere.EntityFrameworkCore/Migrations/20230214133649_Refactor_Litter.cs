using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LS.Cavaliere.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class RefactorLitter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HeroImageUrl",
                table: "Litters",
                newName: "Mother");

            migrationBuilder.AddColumn<string>(
                name: "Father",
                table: "Litters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HeroImage",
                table: "Litters",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Father",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "HeroImage",
                table: "Litters");

            migrationBuilder.RenameColumn(
                name: "Mother",
                table: "Litters",
                newName: "HeroImageUrl");
        }
    }
}
