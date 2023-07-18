using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUni_CarRental.Database.Migrations
{
    public partial class UpdateCarModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b41b30d7-71f7-4f7d-89e7-db86dcc8ae5a", "4628d02f-38f6-47be-a333-e6b730dd7766" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "54f533be-0e09-4055-84f3-d05af1e60fb8", "6bdbaf98-f724-4cb0-90ca-ccb90b3f2859" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54f533be-0e09-4055-84f3-d05af1e60fb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b41b30d7-71f7-4f7d-89e7-db86dcc8ae5a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4628d02f-38f6-47be-a333-e6b730dd7766");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bdbaf98-f724-4cb0-90ca-ccb90b3f2859");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CarRent",
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
                    table.PrimaryKey("PK_CarRent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarRent_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRent_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1db5977f-363f-4e9a-a853-e5680bfe886c", "5d696e00-0c7b-4ee7-adcc-f050fde63278", "Admin", "ADMIN" },
                    { "3429413a-b0e3-4fb8-86b3-39f1d34bf9cf", "b20b16bc-b8b7-44d4-bf4a-373944859ec3", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4e238791-2a8b-49e2-a65e-81680df01962", 0, "6c4fffa1-ab85-4bc9-bb6f-48b3bb5959f0", "admin@carrental.com", false, false, null, "ADMIN@CARRENTAL.COM", "ADMIN@CARRENTAL.COM", "AQAAAAEAACcQAAAAEOuJL17/QLekSuKOt5mAHQQkIAs9Hx/Tw/Ri7fLkVxV5beVhFf/b94bHR/xr/Kg4Bw==", null, false, "14df39fc-e280-4138-b474-3aa79366f21c", false, "admin@carrental.com" },
                    { "9d254ae8-115e-480f-8efe-7798dae95863", 0, "08c6c53c-a6c1-4f6c-bad4-21c2c5a1e69c", "member@carrental.com", false, false, null, "MEMBER@CARRENTAL.COM", "MEMBER@CARRENTAL.COM", "AQAAAAEAACcQAAAAEKAwn7QfDcmE+THCysFFE7G4pvOeCC+L/x5IyDHDM5YqEWNXhn+sxfqc663OOfym2w==", null, false, "87cb0773-cc54-4a45-a9e5-5ec0babe390d", false, "member@carrental.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1db5977f-363f-4e9a-a853-e5680bfe886c", "4e238791-2a8b-49e2-a65e-81680df01962" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3429413a-b0e3-4fb8-86b3-39f1d34bf9cf", "9d254ae8-115e-480f-8efe-7798dae95863" });

            migrationBuilder.CreateIndex(
                name: "IX_CarRent_CarId",
                table: "CarRent",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRent_UserId",
                table: "CarRent",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRent");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1db5977f-363f-4e9a-a853-e5680bfe886c", "4e238791-2a8b-49e2-a65e-81680df01962" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3429413a-b0e3-4fb8-86b3-39f1d34bf9cf", "9d254ae8-115e-480f-8efe-7798dae95863" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1db5977f-363f-4e9a-a853-e5680bfe886c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3429413a-b0e3-4fb8-86b3-39f1d34bf9cf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e238791-2a8b-49e2-a65e-81680df01962");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d254ae8-115e-480f-8efe-7798dae95863");

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
