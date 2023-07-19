using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUni_CarRental.Database.Migrations
{
    public partial class ChangingName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarRents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RentedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarRents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRents_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                });


            migrationBuilder.CreateIndex(
                name: "IX_CarRents_CarId",
                table: "CarRents",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRents_UserId",
                table: "CarRents",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRents");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "da7573f8-c0f9-49d5-8757-928105f93f3a", "1b46cfbe-462d-4648-a979-063a7895e264" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "04d20f5a-b63f-4e86-9dc3-8f2766e08d41", "ac4b6015-b506-41b1-92e3-9a2dc51c20eb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04d20f5a-b63f-4e86-9dc3-8f2766e08d41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da7573f8-c0f9-49d5-8757-928105f93f3a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b46cfbe-462d-4648-a979-063a7895e264");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac4b6015-b506-41b1-92e3-9a2dc51c20eb");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Cars");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54f533be-0e09-4055-84f3-d05af1e60fb8", "525892af-6105-47b0-83e7-225e08132481", "Member", "MEMBER" },
                    { "b41b30d7-71f7-4f7d-89e7-db86dcc8ae5a", "e63a4594-5847-436d-99e1-5f57a67f280d", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4628d02f-38f6-47be-a333-e6b730dd7766", 0, "400a7172-7a67-4902-afcf-c67992ffc231", "admin@carrental.com", false, false, null, "ADMIN@CARRENTAL.COM", "ADMIN@CARRENTAL.COM", "AQAAAAEAACcQAAAAEGYKMcbzxoqHKi5uAnnpS7kdjBT+iytkmOwWn4NXs+RLZLvLvA6eaguiepEJ/V2Pjg==", null, false, "d7aa205e-9ba7-440b-b569-f491de64a459", false, "admin@carrental.com" },
                    { "6bdbaf98-f724-4cb0-90ca-ccb90b3f2859", 0, "ea036885-80f6-40b8-8361-4498b2b0a312", "member@carrental.com", false, false, null, "MEMBER@CARRENTAL.COM", "MEMBER@CARRENTAL.COM", "AQAAAAEAACcQAAAAECol5C5vJnwzVVQYObB90CgmXIKVi7KM3VHIKF6ZMxyyzEm9zTufDloDAwuOWAAnfg==", null, false, "e3548896-cd95-4861-9acf-a915dd327551", false, "member@carrental.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b41b30d7-71f7-4f7d-89e7-db86dcc8ae5a", "4628d02f-38f6-47be-a333-e6b730dd7766" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "54f533be-0e09-4055-84f3-d05af1e60fb8", "6bdbaf98-f724-4cb0-90ca-ccb90b3f2859" });
        }
    }
}
