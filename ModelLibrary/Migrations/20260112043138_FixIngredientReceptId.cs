using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelLibrary.Migrations
{
    /// <inheritdoc />
    public partial class FixIngredientReceptId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "100",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1d8f84a7-5e2b-4d8b-b6b9-c2fb0511f06a", "d5aa959e-7569-443b-acf7-29cb127d68c1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "100",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f4ae7ab8-cc07-45ca-b919-53dc82f92f74", "6509b754-79dd-4ae6-8f5d-fff61f5340c0" });
        }
    }
}
