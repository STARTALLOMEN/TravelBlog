using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class updateDestina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Wards_WardId",
                table: "Destinations");

            migrationBuilder.DropTable(
                name: "Wards");

            migrationBuilder.DropTable(
                name: "Dictricts");

            migrationBuilder.RenameColumn(
                name: "WardId",
                table: "Destinations",
                newName: "ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_Destinations_WardId",
                table: "Destinations",
                newName: "IX_Destinations_ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Provinces_ProvinceId",
                table: "Destinations",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Provinces_ProvinceId",
                table: "Destinations");

            migrationBuilder.RenameColumn(
                name: "ProvinceId",
                table: "Destinations",
                newName: "WardId");

            migrationBuilder.RenameIndex(
                name: "IX_Destinations_ProvinceId",
                table: "Destinations",
                newName: "IX_Destinations_WardId");

            migrationBuilder.CreateTable(
                name: "Dictricts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictricts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dictricts_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DictrictId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wards_Dictricts_DictrictId",
                        column: x => x.DictrictId,
                        principalTable: "Dictricts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dictricts_ProvinceId",
                table: "Dictricts",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Wards_DictrictId",
                table: "Wards",
                column: "DictrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Wards_WardId",
                table: "Destinations",
                column: "WardId",
                principalTable: "Wards",
                principalColumn: "Id");
        }
    }
}
