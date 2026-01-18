using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ModelLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categorieen");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "100",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1a09e30a-2eca-4629-87f6-0f8b073042ea", "cb4d82d9-98d8-4f2f-97e0-0389bc59003d" });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Hoeveelheid", "Naam" },
                values: new object[] { "500g", "Lamsvlees" });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Hoeveelheid", "Naam" },
                values: new object[] { "200g", "Rijst" });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Hoeveelheid", "Naam" },
                values: new object[] { "100g", "Amandelen" });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Hoeveelheid", "Naam" },
                values: new object[] { "50ml", "Olijfolie" });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Hoeveelheid", "Naam" },
                values: new object[] { "2 stuks", "Ui" });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Hoeveelheid", "Naam" },
                values: new object[] { "3 teentjes", "Knoflook" });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "1 tl", "Komijn", 1 });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "1 tl", "Kaneel", 1 });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Hoeveelheid", "Naam", "ReceptId" },
                values: new object[] { "1 stuk", "Sinaasappel", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categorieen",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "100",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "92f1cd03-455c-4dc6-8598-ba616627a6f6", "7b43adc2-6a23-400f-a2f0-a429a62d460f" });

            migrationBuilder.UpdateData(
                table: "Categorieen",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Categorieen",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Categorieen",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Categorieen",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Hoeveelheid", "Naam" },
                values: new object[] { "50ml", "Olijfolie" });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Hoeveelheid", "Naam" },
                values: new object[] { "2 stuks", "Ui" });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Hoeveelheid", "Naam" },
                values: new object[] { "3 teentjes", "Knoflook" });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Hoeveelheid", "Naam" },
                values: new object[] { "1 tl", "Komijn" });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Hoeveelheid", "Naam" },
                values: new object[] { "1 tl", "Kaneel" });

            migrationBuilder.UpdateData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Hoeveelheid", "Naam" },
                values: new object[] { "1 stuk", "Sinaasappel" });

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
    }
}
