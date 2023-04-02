using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlePresenca.Infra.Migrations.UserDb
{
    public partial class tornaemailunico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 88888,
                column: "ConcurrencyStamp",
                value: "179e82db-20ed-4c3c-b829-f9dcc5cb5e2c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "e1a6112b-6536-4e89-a206-cc9f0e5b0776");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 88888,
                column: "ConcurrencyStamp",
                value: "7781ebc1-df49-4c82-acb7-3bd66ac7cd4e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "831ee5ec-7257-4bf5-b6a4-3591330b3979");
        }
    }
}
