using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2939e58f-1b6c-481d-85d4-d045231f39ed", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9571d130-d371-41ec-9880-092257b5ff3d", 0, "3509284e-7051-4beb-be04-9ab3a47fba6a", "admin@yourapp.com", true, false, null, "ADMIN@YOURAPP.COM", "ADMIN@YOURAPP.COM", "AQAAAAIAAYagAAAAECRu+WpIzz7Cczu8w+KAS01dsICsWWNDI8bxB5EjXvtnj+57VYomZUFMiidZPBu4Lw==", null, false, "43d55def-f55f-41b8-a51d-4cfe6f21dc9b", false, "admin@yourapp.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2939e58f-1b6c-481d-85d4-d045231f39ed", "9571d130-d371-41ec-9880-092257b5ff3d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2939e58f-1b6c-481d-85d4-d045231f39ed", "9571d130-d371-41ec-9880-092257b5ff3d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2939e58f-1b6c-481d-85d4-d045231f39ed");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9571d130-d371-41ec-9880-092257b5ff3d");
        }
    }
}
