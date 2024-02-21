using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workers.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Nurs3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerPositions_Position_PositionId",
                table: "WorkerPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerPositions_Workers_WorkerId",
                table: "WorkerPositions");

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "WorkerPositions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "WorkerPositions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerPositions_Position_PositionId",
                table: "WorkerPositions",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerPositions_Workers_WorkerId",
                table: "WorkerPositions",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerPositions_Position_PositionId",
                table: "WorkerPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerPositions_Workers_WorkerId",
                table: "WorkerPositions");

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "WorkerPositions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "WorkerPositions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerPositions_Position_PositionId",
                table: "WorkerPositions",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerPositions_Workers_WorkerId",
                table: "WorkerPositions",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
