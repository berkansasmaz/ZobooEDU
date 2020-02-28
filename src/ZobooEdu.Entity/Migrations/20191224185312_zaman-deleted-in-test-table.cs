using Microsoft.EntityFrameworkCore.Migrations;

namespace ZobooEdu.Entity.Migrations
{
    public partial class zamandeletedintesttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Zaman",
                "Testler");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "Zaman",
                "Testler",
                nullable: false,
                defaultValue: 0);
        }
    }
}