using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ModelLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SeedIngredientsWithReceptId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "100",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "92f1cd03-455c-4dc6-8598-ba616627a6f6", "7b43adc2-6a23-400f-a2f0-a429a62d460f" });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReceptId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "50ml", "Olijfolie", 1 });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "2 stuks", "Ui", 1 });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "3 teentjes", "Knoflook", 1 });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "1 tl", "Komijn", 1 });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "1 tl", "Kaneel", 1 });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "1 stuk", "Sinaasappel", 1 });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "500g", "Lamsvlees", 2 });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "300g", "Tomaten", 2 });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "200g", "Kikkererwten", 2 });

            migrationBuilder.InsertData(
                table: "Ingredienten",
                columns: new[] { "Id", "Hoeveelheid", "IsDeleted", "Naam", "ReceptId" },
                values: new object[,]
                {
                    { 11, "500g", false, "Bloem", 3 },
                    { 12, "250ml", false, "Water", 3 },
                    { 13, "7g", false, "Gist", 3 },
                    { 14, "50g", false, "Sesamzaad", 4 },
                    { 15, "100g", false, "Honing", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "100",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1d8f84a7-5e2b-4d8b-b6b9-c2fb0511f06a", "d5aa959e-7569-443b-acf7-29cb127d68c1" });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReceptId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "500g", "Lamsvlees", 0 });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "200g", "Rijst", 0 });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "100g", "Amandelen", 0 });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "50ml", "Olijfolie", 0 });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "2 stuks", "Ui", 0 });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "3 teentjes", "Knoflook", 0 });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "1 tl", "Komijn", 0 });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "1 tl", "Kaneel", 0 });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "1 stuk", "Sinaasappel", 0 });
        }
    }
}
