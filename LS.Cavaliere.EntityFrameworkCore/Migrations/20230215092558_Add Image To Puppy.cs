using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LS.Cavaliere.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToPuppy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puppy_Litters_LitterId",
                table: "Puppy");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Puppy",
                table: "Puppy");

            migrationBuilder.RenameTable(
                name: "Puppy",
                newName: "Puppies");

            migrationBuilder.RenameIndex(
                name: "IX_Puppy_LitterId",
                table: "Puppies",
                newName: "IX_Puppies_LitterId");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Puppies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Puppies",
                table: "Puppies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Puppies_Litters_LitterId",
                table: "Puppies",
                column: "LitterId",
                principalTable: "Litters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puppies_Litters_LitterId",
                table: "Puppies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Puppies",
                table: "Puppies");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Puppies");

            migrationBuilder.RenameTable(
                name: "Puppies",
                newName: "Puppy");

            migrationBuilder.RenameIndex(
                name: "IX_Puppies_LitterId",
                table: "Puppy",
                newName: "IX_Puppy_LitterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Puppy",
                table: "Puppy",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ContentType = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Puppy_Litters_LitterId",
                table: "Puppy",
                column: "LitterId",
                principalTable: "Litters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
