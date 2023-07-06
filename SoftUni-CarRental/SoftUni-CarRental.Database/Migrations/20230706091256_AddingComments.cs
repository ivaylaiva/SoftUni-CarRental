using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUni_CarRental.Database.Migrations
{
    public partial class AddingComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71192333-1ad9-44ab-b04b-1b89f61bf5c6", "1fd51f8d-722c-4e8d-9a63-445d96295860" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e5306ae8-bfa3-4f89-9bb9-dabba349aea7", "9baa3dcb-3f8c-4ba1-9573-03b85ea95dda" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71192333-1ad9-44ab-b04b-1b89f61bf5c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5306ae8-bfa3-4f89-9bb9-dabba349aea7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1fd51f8d-722c-4e8d-9a63-445d96295860");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baa3dcb-3f8c-4ba1-9573-03b85ea95dda");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "71192333-1ad9-44ab-b04b-1b89f61bf5c6", "77894abe-2c0e-40b2-8641-417d0d0c7a9b", "Admin", "ADMIN" },
                    { "e5306ae8-bfa3-4f89-9bb9-dabba349aea7", "53b7f16c-9997-449e-802d-4807670d0d2b", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1fd51f8d-722c-4e8d-9a63-445d96295860", 0, "a764aecc-79e0-4104-a7e8-73a0cd065578", "admin@carrental.com", false, false, null, "ADMIN@CARRENTAL.COM", "ADMIN@CARRENTAL.COM", "AQAAAAEAACcQAAAAEAE0i/Z5d4bKBDk/C9E3AIMbPGXrAO3Hn/3UFaV0xwW+0RsOcMnZVahdm53uDsByyg==", null, false, "1fb0da18-0920-4e48-b534-1d30d2d42d2b", false, "admin@carrental.com" },
                    { "9baa3dcb-3f8c-4ba1-9573-03b85ea95dda", 0, "6315548f-c0ae-4a5a-b7dd-248adba446de", "member@carrental.com", false, false, null, "MEMBER@CARRENTAL.COM", "MEMBER@CARRENTAL.COM", "AQAAAAEAACcQAAAAEJrHvv4wFO3myCCq8Xf7uQxXokux530+GbqdVKceoneYKtc8bi2Ta/JXbi0ANopvSg==", null, false, "742e40c1-032d-4151-a457-eee1ae18dcc3", false, "member@carrental.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "71192333-1ad9-44ab-b04b-1b89f61bf5c6", "1fd51f8d-722c-4e8d-9a63-445d96295860" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e5306ae8-bfa3-4f89-9bb9-dabba349aea7", "9baa3dcb-3f8c-4ba1-9573-03b85ea95dda" });
        }
    }
}
