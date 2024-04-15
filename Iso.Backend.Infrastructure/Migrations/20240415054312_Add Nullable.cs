using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iso.Backend.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Designs_DesignId",
                table: "OrderDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "DesignId",
                table: "OrderDetail",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Designs_DesignId",
                table: "OrderDetail",
                column: "DesignId",
                principalTable: "Designs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Designs_DesignId",
                table: "OrderDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "DesignId",
                table: "OrderDetail",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Designs_DesignId",
                table: "OrderDetail",
                column: "DesignId",
                principalTable: "Designs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
