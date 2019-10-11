using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Racunala.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Racunalo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Lokacija = table.Column<string>(nullable: true),
                    DatumPustanjaUPromet = table.Column<DateTime>(nullable: false),
                    Aktivno = table.Column<bool>(nullable: false),
                    DanasAktivno = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racunalo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Racunalo");
        }
    }
}
