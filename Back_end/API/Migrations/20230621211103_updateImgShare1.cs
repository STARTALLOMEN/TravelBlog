using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class updateImgShare1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_ImageShares_ImageShareId",
                table: "Destinations");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageShareDestination_Destinations_DestinationId",
                table: "ImageShareDestination");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageShareDestination_ImageShares_ImageShareId",
                table: "ImageShareDestination");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_ImageShareId",
                table: "Destinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageShareDestination",
                table: "ImageShareDestination");

            migrationBuilder.DropColumn(
                name: "ImageShareId",
                table: "Destinations");

            migrationBuilder.RenameTable(
                name: "ImageShareDestination",
                newName: "ImageShareDestinations");

            migrationBuilder.RenameIndex(
                name: "IX_ImageShareDestination_DestinationId",
                table: "ImageShareDestinations",
                newName: "IX_ImageShareDestinations_DestinationId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ImageShares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "ImageShares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageShareDestinations",
                table: "ImageShareDestinations",
                columns: new[] { "ImageShareId", "DestinationId" });

            migrationBuilder.CreateTable(
                name: "ImageShareDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageShareId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageShareDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageShareDetails_ImageShares_ImageShareId",
                        column: x => x.ImageShareId,
                        principalTable: "ImageShares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageShareDetails_ImageShareId",
                table: "ImageShareDetails",
                column: "ImageShareId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageShareDestinations_Destinations_DestinationId",
                table: "ImageShareDestinations",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageShareDestinations_ImageShares_ImageShareId",
                table: "ImageShareDestinations",
                column: "ImageShareId",
                principalTable: "ImageShares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageShareDestinations_Destinations_DestinationId",
                table: "ImageShareDestinations");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageShareDestinations_ImageShares_ImageShareId",
                table: "ImageShareDestinations");

            migrationBuilder.DropTable(
                name: "ImageShareDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageShareDestinations",
                table: "ImageShareDestinations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ImageShares");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "ImageShares");

            migrationBuilder.RenameTable(
                name: "ImageShareDestinations",
                newName: "ImageShareDestination");

            migrationBuilder.RenameIndex(
                name: "IX_ImageShareDestinations_DestinationId",
                table: "ImageShareDestination",
                newName: "IX_ImageShareDestination_DestinationId");

            migrationBuilder.AddColumn<int>(
                name: "ImageShareId",
                table: "Destinations",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageShareDestination",
                table: "ImageShareDestination",
                columns: new[] { "ImageShareId", "DestinationId" });

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_ImageShareId",
                table: "Destinations",
                column: "ImageShareId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_ImageShares_ImageShareId",
                table: "Destinations",
                column: "ImageShareId",
                principalTable: "ImageShares",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageShareDestination_Destinations_DestinationId",
                table: "ImageShareDestination",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageShareDestination_ImageShares_ImageShareId",
                table: "ImageShareDestination",
                column: "ImageShareId",
                principalTable: "ImageShares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
