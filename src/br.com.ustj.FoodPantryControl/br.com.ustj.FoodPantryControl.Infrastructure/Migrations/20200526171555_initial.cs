using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FoodPantryControl");

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "FoodPantryControl",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BarCode = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                schema: "FoodPantryControl",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TypeLog = table.Column<int>(nullable: false),
                    LogDate = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Stacktrace = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item",
                schema: "FoodPantryControl");

            migrationBuilder.DropTable(
                name: "Log",
                schema: "FoodPantryControl");
        }
    }
}
