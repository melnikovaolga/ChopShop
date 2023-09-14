using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChopShop.Api.Dal.Postgres.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Availability = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishName",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    DishId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishName_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishPrice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    DishId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishPrice_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishName_DishId",
                table: "DishName",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishPrice_DishId",
                table: "DishPrice",
                column: "DishId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishName");

            migrationBuilder.DropTable(
                name: "DishPrice");

            migrationBuilder.DropTable(
                name: "Dish");
        }
    }
}
