using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LS.Cavaliere.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToDog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Dogs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Dogs");
        }
    }
}
