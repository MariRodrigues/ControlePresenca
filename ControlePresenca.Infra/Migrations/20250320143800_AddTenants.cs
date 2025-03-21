using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlePresenca.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddTenants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Relatorios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Relatorios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Relatorios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Professores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Professores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Professores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Presencas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Presencas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Presencas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Classes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Classes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Alunos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Alunos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relatorios_TenantId",
                table: "Relatorios",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_TenantId",
                table: "Professores",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Presencas_TenantId",
                table: "Presencas",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TenantId",
                table: "Classes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TenantId",
                table: "AspNetUsers",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TenantId",
                table: "Alunos",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Tenant_TenantId",
                table: "Alunos",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tenant_TenantId",
                table: "AspNetUsers",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Tenant_TenantId",
                table: "Classes",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Presencas_Tenant_TenantId",
                table: "Presencas",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Tenant_TenantId",
                table: "Professores",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Relatorios_Tenant_TenantId",
                table: "Relatorios",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Tenant_TenantId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tenant_TenantId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Tenant_TenantId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Presencas_Tenant_TenantId",
                table: "Presencas");

            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Tenant_TenantId",
                table: "Professores");

            migrationBuilder.DropForeignKey(
                name: "FK_Relatorios_Tenant_TenantId",
                table: "Relatorios");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropIndex(
                name: "IX_Relatorios_TenantId",
                table: "Relatorios");

            migrationBuilder.DropIndex(
                name: "IX_Professores_TenantId",
                table: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Presencas_TenantId",
                table: "Presencas");

            migrationBuilder.DropIndex(
                name: "IX_Classes_TenantId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TenantId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TenantId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Relatorios");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Relatorios");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Relatorios");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Presencas");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Presencas");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Presencas");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Alunos");
        }
    }
}
