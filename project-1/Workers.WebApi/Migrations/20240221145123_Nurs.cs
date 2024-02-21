using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workers.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Nurs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Genders_GenderId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Position_PositionId",
                table: "Workers");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Genders_GenderId",
                table: "Workers",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Position_PositionId",
                table: "Workers",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Genders_GenderId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Position_PositionId",
                table: "Workers");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Genders_GenderId",
                table: "Workers",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Position_PositionId",
                table: "Workers",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
