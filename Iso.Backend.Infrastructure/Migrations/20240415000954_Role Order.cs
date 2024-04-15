using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iso.Backend.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class RoleOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Designs",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Designs_UserId",
                table: "Designs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Designs_Users_UserId",
                table: "Designs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Designs_Users_UserId",
                table: "Designs");

            migrationBuilder.DropIndex(
                name: "IX_Designs_UserId",
                table: "Designs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Designs");
        }
    }
}
