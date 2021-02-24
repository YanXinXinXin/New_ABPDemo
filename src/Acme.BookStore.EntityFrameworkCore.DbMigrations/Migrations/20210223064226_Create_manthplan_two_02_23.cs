using Microsoft.EntityFrameworkCore.Migrations;

namespace Acme.BookStore.Migrations
{
    public partial class Create_manthplan_two_02_23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "AppMonthlPlanTables");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "AppMonthlPlanTables");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "AppMonthlPlanTables");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "AppMonthlPlanTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "AppMonthlPlanTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "AppMonthlPlanTables",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
