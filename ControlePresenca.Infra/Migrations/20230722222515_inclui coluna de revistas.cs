using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlePresenca.Infra.Migrations
{
    public partial class incluicolunaderevistas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantidadeRevistas",
                table: "Relatorios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeRevistas",
                table: "Relatorios");
        }
    }
}
