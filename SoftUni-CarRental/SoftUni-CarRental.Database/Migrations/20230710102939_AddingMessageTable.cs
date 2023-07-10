using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUni_CarRental.Database.Migrations
{
    public partial class AddingMessageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fe0d9beb-a964-45b5-ba7e-49a7e8e81f6a", "68431cef-9cac-48f3-bf11-77e9dfcdc323" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b9ca34e2-9761-47ab-b81e-81340f6c906b", "dcbdb7aa-924a-4a85-99b7-de2d3867e942" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9ca34e2-9761-47ab-b81e-81340f6c906b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe0d9beb-a964-45b5-ba7e-49a7e8e81f6a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "68431cef-9cac-48f3-bf11-77e9dfcdc323");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dcbdb7aa-924a-4a85-99b7-de2d3867e942");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b9ca34e2-9761-47ab-b81e-81340f6c906b", "4c522980-9117-4824-979f-caaa9022dd02", "Admin", "ADMIN" },
                    { "fe0d9beb-a964-45b5-ba7e-49a7e8e81f6a", "b798d11d-c366-4dca-8da6-d2724ba7d1c1", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "68431cef-9cac-48f3-bf11-77e9dfcdc323", 0, "6e3ffea2-3934-4911-8ba5-9ead52d84860", "member@carrental.com", false, false, null, "MEMBER@CARRENTAL.COM", "MEMBER@CARRENTAL.COM", "AQAAAAEAACcQAAAAEMt4k4a7XLJgYGjdLEFNcv357HVBfYGVrITqbG05ERJUNoO9HZljNOHaO8u9044CYQ==", null, false, "fe39c7b9-b8fa-4f7a-a960-0c1b95071889", false, "member@carrental.com" },
                    { "dcbdb7aa-924a-4a85-99b7-de2d3867e942", 0, "b1055290-1652-4177-b1d1-3cc0f80d9af7", "admin@carrental.com", false, false, null, "ADMIN@CARRENTAL.COM", "ADMIN@CARRENTAL.COM", "AQAAAAEAACcQAAAAELn1E9+fAK4Nzz1wbJIygRKHu6UuWw2dgYzGxkSuqzIEEiJnFGUK1NRehIe908Yd8w==", null, false, "d572cb86-c56e-4293-8fed-a2a9bb6649e0", false, "admin@carrental.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fe0d9beb-a964-45b5-ba7e-49a7e8e81f6a", "68431cef-9cac-48f3-bf11-77e9dfcdc323" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b9ca34e2-9761-47ab-b81e-81340f6c906b", "dcbdb7aa-924a-4a85-99b7-de2d3867e942" });
        }
    }
}
