using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iso.Backend.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Addsomerels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CommentItems_CommentItemId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Designs_DesignId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Items_ItemId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CommentItemId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DesignId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ItemId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CommentItemId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DesignId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_DesignId",
                table: "OrderDetail",
                column: "DesignId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ItemId",
                table: "OrderDetail",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentItems_DesignId",
                table: "CommentItems",
                column: "DesignId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentItems_ItemId",
                table: "CommentItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentItems_UserId",
                table: "CommentItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentItems_Designs_DesignId",
                table: "CommentItems",
                column: "DesignId",
                principalTable: "Designs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentItems_Items_ItemId",
                table: "CommentItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentItems_Users_UserId",
                table: "CommentItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Designs_DesignId",
                table: "OrderDetail",
                column: "DesignId",
                principalTable: "Designs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Items_ItemId",
                table: "OrderDetail",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentItems_Designs_DesignId",
                table: "CommentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentItems_Items_ItemId",
                table: "CommentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentItems_Users_UserId",
                table: "CommentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Designs_DesignId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Items_ItemId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_DesignId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_ItemId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_CommentItems_DesignId",
                table: "CommentItems");

            migrationBuilder.DropIndex(
                name: "IX_CommentItems_ItemId",
                table: "CommentItems");

            migrationBuilder.DropIndex(
                name: "IX_CommentItems_UserId",
                table: "CommentItems");

            migrationBuilder.AddColumn<Guid>(
                name: "CommentItemId",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DesignId",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CommentItemId",
                table: "Orders",
                column: "CommentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DesignId",
                table: "Orders",
                column: "DesignId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ItemId",
                table: "Orders",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CommentItems_CommentItemId",
                table: "Orders",
                column: "CommentItemId",
                principalTable: "CommentItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Designs_DesignId",
                table: "Orders",
                column: "DesignId",
                principalTable: "Designs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Items_ItemId",
                table: "Orders",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }
    }
}
