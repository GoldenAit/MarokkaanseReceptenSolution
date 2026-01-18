using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ModelLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recepten_Categorieën_CategorieId",
                table: "Recepten");

            migrationBuilder.DropTable(
                name: "Categorieën");

            migrationBuilder.DropTable(
                name: "Ingrediënten");

            migrationBuilder.AddColumn<string>(
                name: "VolledigeNaam",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Categorieen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorieen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredienten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hoeveelheid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceptId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredienten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredienten_Recepten_ReceptId",
                        column: x => x.ReceptId,
                        principalTable: "Recepten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FavoriteCuisine", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VolledigeNaam" },
                values: new object[] { "100", 0, "f4ae7ab8-cc07-45ca-b919-53dc82f92f74", "admin@marokkaans.be", true, "Marokkaans", false, null, "ADMIN@MAROKKAANS.BE", "ADMIN@MAROKKAANS.BE", "AQAAAAIAAYagAAAAEK8D3dMZx+7cOeFhvI0/b4mcyQmRleN8zB1WJZTfT4xPj7u3YtJ+EztqMIAlMCsNw==", null, false, "6509b754-79dd-4ae6-8f5d-fff61f5340c0", false, "admin@marokkaans.be", "Admin Marokkaans" });

            migrationBuilder.InsertData(
                table: "Categorieen",
                columns: new[] { "Id", "IsDeleted", "Naam" },
                values: new object[,]
                {
                    { 1, false, "Hoofdgerechten" },
                    { 2, false, "Soepen" },
                    { 3, false, "Brood" },
                    { 4, false, "Zoetigheden" }
                });

            migrationBuilder.InsertData(
                table: "Ingredienten",
                columns: new[] { "Id", "Hoeveelheid", "IsDeleted", "Naam", "ReceptId" },
                values: new object[,]
                {
                    { 1, "500g", false, "Kip", 0 },
                    { 2, "500g", false, "Lamsvlees", 0 },
                    { 3, "200g", false, "Rijst", 0 },
                    { 4, "100g", false, "Amandelen", 0 },
                    { 5, "50ml", false, "Olijfolie", 0 },
                    { 6, "2 stuks", false, "Ui", 0 },
                    { 7, "3 teentjes", false, "Knoflook", 0 },
                    { 8, "1 tl", false, "Komijn", 0 },
                    { 9, "1 tl", false, "Kaneel", 0 },
                    { 10, "1 stuk", false, "Sinaasappel", 0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "100" });

            migrationBuilder.InsertData(
                table: "Recepten",
                columns: new[] { "Id", "Bereiding", "CategorieId", "FotoPad", "Herkomst", "IsDeleted", "Naam" },
                values: new object[,]
                {
                    { 1, "Traditionele Marokkaanse kip-tajine met groenten en kruiden.", 1, "", "Marokko", false, "Tajine met kip" },
                    { 2, "Heerlijke Marokkaanse soep, vaak gegeten tijdens Ramadan.", 2, "", "Marokko", false, "Harira" },
                    { 3, "Traditioneel Marokkaans brood.", 3, "", "Marokko", false, "Khobz" },
                    { 4, "Marokkaanse zoetigheid met honing en sesam.", 4, "", "Marokko", false, "Chebakia" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredienten_ReceptId",
                table: "Ingredienten",
                column: "ReceptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recepten_Categorieen_CategorieId",
                table: "Recepten",
                column: "CategorieId",
                principalTable: "Categorieen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recepten_Categorieen_CategorieId",
                table: "Recepten");

            migrationBuilder.DropTable(
                name: "Categorieen");

            migrationBuilder.DropTable(
                name: "Ingredienten");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "100" });

            migrationBuilder.DeleteData(
                table: "Recepten",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recepten",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recepten",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recepten",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "100");

            migrationBuilder.DropColumn(
                name: "VolledigeNaam",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Categorieën",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorieën", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingrediënten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceptId = table.Column<int>(type: "int", nullable: false),
                    Hoeveelheid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediënten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingrediënten_Recepten_ReceptId",
                        column: x => x.ReceptId,
                        principalTable: "Recepten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediënten_ReceptId",
                table: "Ingrediënten",
                column: "ReceptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recepten_Categorieën_CategorieId",
                table: "Recepten",
                column: "CategorieId",
                principalTable: "Categorieën",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
