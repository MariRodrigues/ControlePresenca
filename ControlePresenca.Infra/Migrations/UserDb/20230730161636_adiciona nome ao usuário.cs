using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlePresenca.Infra.Migrations.UserDb
{
    public partial class adicionanomeaousuário : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 88888,
                column: "ConcurrencyStamp",
                value: "8aab8476-3b10-4140-869c-49054c0e63c0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "9393615e-d797-4407-8fcc-b9c1deac4c67");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 88888,
                column: "ConcurrencyStamp",
                value: "6dc25f0a-994d-44dc-8acd-ed1ae41f2b14");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "c0b9f5b5-adcb-4c37-9bb7-5b9c22ea8a60");
        }
    }
}
