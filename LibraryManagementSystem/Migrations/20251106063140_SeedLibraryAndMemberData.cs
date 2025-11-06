using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedLibraryAndMemberData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "Main Road", "Central City Library" },
                    { 2, "Park Street", "Community Library" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "alice@example.com", "Alice Johnson" },
                    { 2, "bob@example.com", "Bob Williams" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
