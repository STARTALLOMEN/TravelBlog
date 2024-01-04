using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class updateDBs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Provinces_ProvinceId",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "TimeVisitRecomment",
                table: "ReviewDestinations");

            migrationBuilder.DropColumn(
                name: "WhenGo",
                table: "ReviewDestinations");

            migrationBuilder.DropColumn(
                name: "WhoGoTogether",
                table: "ReviewDestinations");

            migrationBuilder.AlterColumn<int>(
                name: "ProvinceId",
                table: "Destinations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Provinces_ProvinceId",
                table: "Destinations",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Provinces_ProvinceId",
                table: "Destinations");

            migrationBuilder.AddColumn<string>(
                name: "TimeVisitRecomment",
                table: "ReviewDestinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WhenGo",
                table: "ReviewDestinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WhoGoTogether",
                table: "ReviewDestinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ProvinceId",
                table: "Destinations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Provinces_ProvinceId",
                table: "Destinations",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id");
        }
    }
}
