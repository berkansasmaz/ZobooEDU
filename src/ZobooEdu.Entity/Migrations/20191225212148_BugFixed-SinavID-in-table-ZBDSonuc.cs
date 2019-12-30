using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZobooEdu.Entity.Migrations
{
    public partial class BugFixedSinavIDintableZBDSonuc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sonuclar",
                columns: table => new
                {
                    SonucId = table.Column<Guid>(nullable: false),
                    Konu = table.Column<string>(nullable: true),
                    isDogruMu = table.Column<bool>(nullable: false),
                    sınavID = table.Column<int>(nullable: false),
                    isBittiMi = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sonuclar", x => x.SonucId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sonuclar");
        }
    }
}
