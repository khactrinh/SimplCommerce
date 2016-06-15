using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimplCommerce.Web.Migrations
{
    public partial class ReModelProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Core_ProductOptionCombination_Core_ProductVariation_VariationId",
                table: "Core_ProductOptionCombination");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CartItem_Core_ProductVariation_ProductVariationId",
                table: "Orders_CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderItem_Core_ProductVariation_ProductVariationId",
                table: "Orders_OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderItem_ProductVariationId",
                table: "Orders_OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CartItem_ProductVariationId",
                table: "Orders_CartItem");

            migrationBuilder.DropIndex(
                name: "IX_Core_ProductOptionCombination_VariationId",
                table: "Core_ProductOptionCombination");

            migrationBuilder.DropColumn(
                name: "ProductVariationId",
                table: "Orders_OrderItem");

            migrationBuilder.DropColumn(
                name: "ProductVariationId",
                table: "Orders_CartItem");

            migrationBuilder.DropColumn(
                name: "VariationId",
                table: "Core_ProductOptionCombination");

            migrationBuilder.DropTable(
                name: "Core_ProductVariation");

            migrationBuilder.CreateTable(
                name: "Core_ProductLink",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LinkType = table.Column<int>(nullable: false),
                    LinkedProductId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_ProductLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_ProductLink_Core_Product_LinkedProductId",
                        column: x => x.LinkedProductId,
                        principalTable: "Core_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_ProductLink_Core_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Core_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<long>(
                name: "ProducdtId",
                table: "Core_ProductOptionCombination",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "Core_ProductOptionCombination",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductOptionCombination_ProductId",
                table: "Core_ProductOptionCombination",
                column: "ProductId");

            migrationBuilder.AddColumn<bool>(
                name: "HasOptions",
                table: "Core_Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisibleIndividually",
                table: "Core_Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Sku",
                table: "Core_Product",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductLink_LinkedProductId",
                table: "Core_ProductLink",
                column: "LinkedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductLink_ProductId",
                table: "Core_ProductLink",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Core_ProductOptionCombination_Core_Product_ProductId",
                table: "Core_ProductOptionCombination",
                column: "ProductId",
                principalTable: "Core_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Core_ProductOptionCombination_Core_Product_ProductId",
                table: "Core_ProductOptionCombination");

            migrationBuilder.DropIndex(
                name: "IX_Core_ProductOptionCombination_ProductId",
                table: "Core_ProductOptionCombination");

            migrationBuilder.DropColumn(
                name: "ProducdtId",
                table: "Core_ProductOptionCombination");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Core_ProductOptionCombination");

            migrationBuilder.DropColumn(
                name: "HasOptions",
                table: "Core_Product");

            migrationBuilder.DropColumn(
                name: "IsVisibleIndividually",
                table: "Core_Product");

            migrationBuilder.DropColumn(
                name: "Sku",
                table: "Core_Product");

            migrationBuilder.DropTable(
                name: "Core_ProductLink");

            migrationBuilder.CreateTable(
                name: "Core_ProductVariation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<long>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    IsAllowOrder = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PriceOffset = table.Column<decimal>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    ReasonNotAllowOrder = table.Column<string>(nullable: true),
                    Sku = table.Column<string>(nullable: true),
                    UpdatedById = table.Column<long>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_ProductVariation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_ProductVariation_Core_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_ProductVariation_Core_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Core_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Core_ProductVariation_Core_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<long>(
                name: "ProductVariationId",
                table: "Orders_OrderItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderItem_ProductVariationId",
                table: "Orders_OrderItem",
                column: "ProductVariationId");

            migrationBuilder.AddColumn<long>(
                name: "ProductVariationId",
                table: "Orders_CartItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartItem_ProductVariationId",
                table: "Orders_CartItem",
                column: "ProductVariationId");

            migrationBuilder.AddColumn<long>(
                name: "VariationId",
                table: "Core_ProductOptionCombination",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductOptionCombination_VariationId",
                table: "Core_ProductOptionCombination",
                column: "VariationId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductVariation_CreatedById",
                table: "Core_ProductVariation",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductVariation_ProductId",
                table: "Core_ProductVariation",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductVariation_UpdatedById",
                table: "Core_ProductVariation",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Core_ProductOptionCombination_Core_ProductVariation_VariationId",
                table: "Core_ProductOptionCombination",
                column: "VariationId",
                principalTable: "Core_ProductVariation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CartItem_Core_ProductVariation_ProductVariationId",
                table: "Orders_CartItem",
                column: "ProductVariationId",
                principalTable: "Core_ProductVariation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderItem_Core_ProductVariation_ProductVariationId",
                table: "Orders_OrderItem",
                column: "ProductVariationId",
                principalTable: "Core_ProductVariation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
