using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Workers.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class newModels : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_Workers_GenderId",
                table: "Workers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Workers",
                newName: "WorkerId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Workers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Workers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "GenderId1",
                table: "Workers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" },
                    { 3, "Non-binary" },
                    { 4, "Prefer not to say" },
                    { 5, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Software Engineer" },
                    { 2, "Data Scientist" },
                    { 3, "Product Manager" },
                    { 4, "UX/UI Designer" },
                    { 5, "QA Engineer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_GenderId",
                table: "Workers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_GenderId1",
                table: "Workers",
                column: "GenderId1",
                unique: true,
                filter: "[GenderId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Genders_GenderId",
                table: "Workers",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Genders_GenderId1",
                table: "Workers",
                column: "GenderId1",
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
                name: "FK_Workers_Genders_GenderId1",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Position_PositionId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_GenderId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_GenderId1",
                table: "Workers");

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "GenderId1",
                table: "Workers");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "Workers",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_GenderId",
                table: "Workers",
                column: "GenderId",
                unique: true);

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
