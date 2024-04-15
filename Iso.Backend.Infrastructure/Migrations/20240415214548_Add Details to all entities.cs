using Iso.Backend.Domain.Entities.JsonModels;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iso.Backend.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDetailstoallentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<OrderDetails>(
                name: "Details",
                table: "Orders",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<OrderDetailsMetadata>(
                name: "Details",
                table: "OrderDetail",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<ItemDetails>(
                name: "Details",
                table: "Items",
                type: "jsonb",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Items");
        }
    }
}
