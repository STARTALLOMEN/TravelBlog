using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class updateDesti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProvinceOrArea",
                table: "Destinations");

            migrationBuilder.AddColumn<int>(
                name: "ProvinceOrAreaOrPrArea",
                table: "Destinations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProvinceOrAreaOrPrArea",
                table: "Destinations");

            migrationBuilder.AddColumn<bool>(
                name: "ProvinceOrArea",
                table: "Destinations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
