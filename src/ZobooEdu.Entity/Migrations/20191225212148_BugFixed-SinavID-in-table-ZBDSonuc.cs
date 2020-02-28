using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZobooEdu.Entity.Migrations
{
    public partial class BugFixedSinavIDintableZBDSonuc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Sonuclar",
                table => new
                {
                    SonucId = table.Column<Guid>(),
                    Konu = table.Column<string>(nullable: true),
                    isDogruMu = table.Column<bool>(),
                    sınavID = table.Column<int>(),
                    isBittiMi = table.Column<bool>()
                },
                constraints: table => { table.PrimaryKey("PK_Sonuclar", x => x.SonucId); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Sonuclar");
        }
    }
}