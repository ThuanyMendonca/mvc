using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teste.Migrations
{
    public partial class addingpontosfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pontos",
                table: "Teste",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pontos",
                table: "Teste");
        }
    }
}
