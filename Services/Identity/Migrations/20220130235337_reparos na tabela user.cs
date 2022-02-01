using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Migrations
{
    public partial class reparosnatabelauser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4d92915b-fe80-41eb-9c6d-6c6b03801c6b"),
                column: "ConcurrencyStamp",
                value: "46071816-9af4-471d-9e05-94ddfc33dc1c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e5ca3e84-6ca9-473f-966c-76291e0d84fc"),
                column: "ConcurrencyStamp",
                value: "b473cdf6-d705-4b71-afc7-66a978528126");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1329fa77-e1ee-4f86-81c5-c8112ecbfacc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6cc1b14-f69d-4a9e-84ac-de952f8758c3", "AQAAAAEAACcQAAAAELG/uXkTtZ8asPcX+widyWczxCSUgLPOy39iyvk0+MloJpRrCs2ozDydF1CMLr2mEg==", "23f5d0e7-308e-4438-83a4-589682c002e5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4d92915b-fe80-41eb-9c6d-6c6b03801c6b"),
                column: "ConcurrencyStamp",
                value: "ddefa254-9a82-459e-b444-b2fa3ed33fd6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e5ca3e84-6ca9-473f-966c-76291e0d84fc"),
                column: "ConcurrencyStamp",
                value: "4935fc87-bc63-4263-9caa-41c5e268085d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1329fa77-e1ee-4f86-81c5-c8112ecbfacc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f327a721-1c3f-4a0c-a20c-5e04e6d0ced8", "AQAAAAEAACcQAAAAEE42kKgdlsd0wBmOQj6C04MnIsNaN83b3x3AxurmoHPYItlDoN5K9z0p0tZ3pAtMCg==", "2c80ff9a-209f-41aa-b5b6-50a97761d520" });
        }
    }
}
