using Microsoft.EntityFrameworkCore.Migrations;

namespace Acme.BookStore.Migrations
{
    public partial class UpdateMonthPlans_02_20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AchievementOfSuperiorReviewGoals",
                table: "AppMonthlPlanTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActualCompletion",
                table: "AppMonthlPlanTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActualCompletionTime",
                table: "AppMonthlPlanTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelfRating",
                table: "AppMonthlPlanTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SuperiorScore",
                table: "AppMonthlPlanTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaskCompletionRate",
                table: "AppMonthlPlanTables",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AchievementOfSuperiorReviewGoals",
                table: "AppMonthlPlanTables");

            migrationBuilder.DropColumn(
                name: "ActualCompletion",
                table: "AppMonthlPlanTables");

            migrationBuilder.DropColumn(
                name: "ActualCompletionTime",
                table: "AppMonthlPlanTables");

            migrationBuilder.DropColumn(
                name: "SelfRating",
                table: "AppMonthlPlanTables");

            migrationBuilder.DropColumn(
                name: "SuperiorScore",
                table: "AppMonthlPlanTables");

            migrationBuilder.DropColumn(
                name: "TaskCompletionRate",
                table: "AppMonthlPlanTables");
        }
    }
}
