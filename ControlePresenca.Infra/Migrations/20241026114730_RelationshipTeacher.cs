using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlePresenca.Infra.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Classes_ClasseId",
                table: "Professores");

            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "Relatorios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ClasseId",
                table: "Professores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorios_ProfessorId",
                table: "Relatorios",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Classes_ClasseId",
                table: "Professores",
                column: "ClasseId",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Relatorios_Professores_ProfessorId",
                table: "Relatorios",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Classes_ClasseId",
                table: "Professores");

            migrationBuilder.DropForeignKey(
                name: "FK_Relatorios_Professores_ProfessorId",
                table: "Relatorios");

            migrationBuilder.DropIndex(
                name: "IX_Relatorios_ProfessorId",
                table: "Relatorios");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Relatorios");

            migrationBuilder.AlterColumn<int>(
                name: "ClasseId",
                table: "Professores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Classes_ClasseId",
                table: "Professores",
                column: "ClasseId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
