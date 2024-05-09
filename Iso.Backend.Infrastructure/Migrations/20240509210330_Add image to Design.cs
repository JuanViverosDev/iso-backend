using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iso.Backend.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddimagetoDesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainImage",
                table: "Designs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "Designs");
        }
    }
}
