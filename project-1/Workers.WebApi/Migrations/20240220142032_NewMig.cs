using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workers.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class NewMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WorkerPositions_WorkerId",
                table: "WorkerPositions",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerPositions_Workers_WorkerId",
                table: "WorkerPositions",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerPositions_Workers_WorkerId",
                table: "WorkerPositions");

            migrationBuilder.DropIndex(
                name: "IX_WorkerPositions_WorkerId",
                table: "WorkerPositions");
        }
    }
}
