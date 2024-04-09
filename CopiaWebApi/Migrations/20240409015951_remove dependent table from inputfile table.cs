using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopiaWebApi.Migrations
{
    /// <inheritdoc />
    public partial class removedependenttablefrominputfiletable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputOutputMappers_InputFiles_InputFileId",
                table: "InputOutputMappers");

            migrationBuilder.DropIndex(
                name: "IX_InputOutputMappers_InputFileId",
                table: "InputOutputMappers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_InputOutputMappers_InputFileId",
                table: "InputOutputMappers",
                column: "InputFileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InputOutputMappers_InputFiles_InputFileId",
                table: "InputOutputMappers",
                column: "InputFileId",
                principalTable: "InputFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
