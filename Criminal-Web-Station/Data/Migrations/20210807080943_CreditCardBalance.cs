using Microsoft.EntityFrameworkCore.Migrations;

namespace Criminal_Web_Station.Data.Migrations
{
    public partial class CreditCardBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "CreditCards",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "CreditCards");
        }
    }
}
