using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class updatePlan1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinationPlanDate");

            migrationBuilder.DropTable(
                name: "PlanDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanDate_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DestinationPlanDate",
                columns: table => new
                {
                    DestinationsId = table.Column<int>(type: "int", nullable: false),
                    PlanDatesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationPlanDate", x => new { x.DestinationsId, x.PlanDatesId });
                    table.ForeignKey(
                        name: "FK_DestinationPlanDate_Destinations_DestinationsId",
                        column: x => x.DestinationsId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestinationPlanDate_PlanDate_PlanDatesId",
                        column: x => x.PlanDatesId,
                        principalTable: "PlanDate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestinationPlanDate_PlanDatesId",
                table: "DestinationPlanDate",
                column: "PlanDatesId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDate_PlanId",
                table: "PlanDate",
                column: "PlanId");
        }
    }
}
