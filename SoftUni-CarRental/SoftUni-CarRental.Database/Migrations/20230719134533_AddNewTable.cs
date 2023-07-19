using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUni_CarRental.Database.Migrations
{
    public partial class AddNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRentCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarCardId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RentedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FreeOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRentCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRentCars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRentCars_CarCards_CarCardId",
                        column: x => x.CarCardId,
                        principalTable: "CarCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRentCars_CarCardId",
                table: "UserRentCars",
                column: "CarCardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRentCars_UserId",
                table: "UserRentCars",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRentCars");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e0645c2b-5d3a-43cf-9738-99c598143b15", "43e590e9-6ad1-4bb6-97b1-3f08ef2f7e0c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ac44f967-e83f-48de-88f8-e7a0fd614fa7", "bb4e6321-2d80-4537-8d7d-09b8728bf0ea" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac44f967-e83f-48de-88f8-e7a0fd614fa7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0645c2b-5d3a-43cf-9738-99c598143b15");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43e590e9-6ad1-4bb6-97b1-3f08ef2f7e0c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb4e6321-2d80-4537-8d7d-09b8728bf0ea");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04d20f5a-b63f-4e86-9dc3-8f2766e08d41", "bb5c4c2c-f4ff-4799-9c72-b18c8e593ea1", "Admin", "ADMIN" },
                    { "da7573f8-c0f9-49d5-8757-928105f93f3a", "a301179a-978c-4c49-b95d-51e6ea64cfaf", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1b46cfbe-462d-4648-a979-063a7895e264", 0, "6b2e6224-02fb-43fd-a06e-57c383c0f7be", "member@carrental.com", false, false, null, "MEMBER@CARRENTAL.COM", "MEMBER@CARRENTAL.COM", "AQAAAAEAACcQAAAAEMhqW4C33wytSpfd4eIVGX0VVGdnhl/aqSJhRhpCYrvYve9/jW364pitLZxicglg9g==", null, false, "52748566-f11c-4514-b336-cf4b20c5c96d", false, "member@carrental.com" },
                    { "ac4b6015-b506-41b1-92e3-9a2dc51c20eb", 0, "5b9fb9b0-349f-4e48-b3bd-e2a508351fb8", "admin@carrental.com", false, false, null, "ADMIN@CARRENTAL.COM", "ADMIN@CARRENTAL.COM", "AQAAAAEAACcQAAAAEJjZ5OI7sVy/iRd5dqV5d1aV7tjTI6FuNynHd2KCclerPwGo81JjSfemvKPf93wJkg==", null, false, "be9a8e90-fcf0-42c4-ab6c-cde38de6e5b8", false, "admin@carrental.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "da7573f8-c0f9-49d5-8757-928105f93f3a", "1b46cfbe-462d-4648-a979-063a7895e264" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "04d20f5a-b63f-4e86-9dc3-8f2766e08d41", "ac4b6015-b506-41b1-92e3-9a2dc51c20eb" });
        }
    }
}
