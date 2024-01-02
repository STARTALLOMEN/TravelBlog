using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class updatePlans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinationPlanDate_PlanDates_PlanDatesId",
                table: "DestinationPlanDate");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDates_Plans_PlanId",
                table: "PlanDates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanDates",
                table: "PlanDates");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "TotalDays",
                table: "Plans");

            migrationBuilder.RenameTable(
                name: "PlanDates",
                newName: "PlanDate");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDates_PlanId",
                table: "PlanDate",
                newName: "IX_PlanDate_PlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanDate",
                table: "PlanDate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationPlanDate_PlanDate_PlanDatesId",
                table: "DestinationPlanDate",
                column: "PlanDatesId",
                principalTable: "PlanDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDate_Plans_PlanId",
                table: "PlanDate",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinationPlanDate_PlanDate_PlanDatesId",
                table: "DestinationPlanDate");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDate_Plans_PlanId",
                table: "PlanDate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanDate",
                table: "PlanDate");

            migrationBuilder.RenameTable(
                name: "PlanDate",
                newName: "PlanDates");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDate_PlanId",
                table: "PlanDates",
                newName: "IX_PlanDates_PlanId");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Plans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Plans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalDays",
                table: "Plans",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanDates",
                table: "PlanDates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationPlanDate_PlanDates_PlanDatesId",
                table: "DestinationPlanDate",
                column: "PlanDatesId",
                principalTable: "PlanDates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDates_Plans_PlanId",
                table: "PlanDates",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
