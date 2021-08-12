using Microsoft.EntityFrameworkCore.Migrations;

namespace Criminal_Web_Station.Data.Migrations
{
    public partial class BanTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BanId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bans",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccoundId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannedForSeconds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bans", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BanId",
                table: "AspNetUsers",
                column: "BanId",
                unique: true,
                filter: "[BanId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Bans_BanId",
                table: "AspNetUsers",
                column: "BanId",
                principalTable: "Bans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Bans_BanId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Bans");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BanId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BanId",
                table: "AspNetUsers");
        }
    }
}
