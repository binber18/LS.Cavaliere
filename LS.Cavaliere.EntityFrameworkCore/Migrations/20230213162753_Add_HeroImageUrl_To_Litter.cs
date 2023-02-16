using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LS.Cavaliere.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddHeroImageUrlToLitter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeroImageUrl",
                table: "Litters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeroImageUrl",
                table: "Litters");
        }
    }
}
