using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkforceHubAPI.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f79f0e3-79f1-4e1c-9255-7cb963464c7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7251d5fa-2f73-49d5-8443-4ef2924bc16c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e0eed4f-1476-4ca7-9f5a-bc4cf6dc7f27", null, "Administrator", "ADMINISTRATOR" },
                    { "456ac4f6-d40a-437b-ad56-02dc4ca48af4", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e0eed4f-1476-4ca7-9f5a-bc4cf6dc7f27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "456ac4f6-d40a-437b-ad56-02dc4ca48af4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f79f0e3-79f1-4e1c-9255-7cb963464c7a", null, "Administrator", "ADMINISTRATOR" },
                    { "7251d5fa-2f73-49d5-8443-4ef2924bc16c", null, "Manager", "MANAGER" }
                });
        }
    }
}
