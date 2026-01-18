using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ModelLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "100",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "19aa1de5-459f-4a27-aef3-61624bacefbf", "8e76db11-def4-4c74-9937-df29ffe2543b" });

            migrationBuilder.InsertData(
                table: "Ingredienten",
                columns: new[] { "Id", "Hoeveelheid", "IsDeleted", "Naam", "ReceptId" },
                values: new object[,]
                {
                    { -10, "1 stuk", false, "Sinaasappel", 1 },
                    { -9, "1 tl", false, "Kaneel", 1 },
                    { -8, "1 tl", false, "Komijn", 1 },
                    { -7, "3 teentjes", false, "Knoflook", 1 },
                    { -6, "2 stuks", false, "Ui", 1 },
                    { -5, "50ml", false, "Olijfolie", 1 },
                    { -4, "100g", false, "Amandelen", 1 },
                    { -3, "200g", false, "Rijst", 1 },
                    { -2, "500g", false, "Lamsvlees", 1 },
                    { -1, "500g", false, "Kip", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "100",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1a09e30a-2eca-4629-87f6-0f8b073042ea", "cb4d82d9-98d8-4f2f-97e0-0389bc59003d" });

            migrationBuilder.InsertData(
                table: "Ingredienten",
                columns: new[] { "Id", "Hoeveelheid", "IsDeleted", "Naam", "ReceptId" },
                values: new object[,]
                {
                    { 1, "500g", false, "Kip", 1 },
                    { 2, "500g", false, "Lamsvlees", 1 },
                    { 3, "200g", false, "Rijst", 1 },
                    { 4, "100g", false, "Amandelen", 1 },
                    { 5, "50ml", false, "Olijfolie", 1 },
                    { 6, "2 stuks", false, "Ui", 1 },
                    { 7, "3 teentjes", false, "Knoflook", 1 },
                    { 8, "1 tl", false, "Komijn", 1 },
                    { 9, "1 tl", false, "Kaneel", 1 },
                    { 10, "1 stuk", false, "Sinaasappel", 1 }
                });
        }
    }
}
