using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopiaWebApi.Migrations
{
    /// <inheritdoc />
    public partial class defineforeignkeyrelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_InputOutputMappers_InputFileId",
                table: "InputOutputMappers",
                column: "InputFileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InputOutputMappers_OutputFileId",
                table: "InputOutputMappers",
                column: "OutputFileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InputOutputMappers_InputFiles_InputFileId",
                table: "InputOutputMappers",
                column: "InputFileId",
                principalTable: "InputFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InputOutputMappers_OutputFiles_OutputFileId",
                table: "InputOutputMappers",
                column: "OutputFileId",
                principalTable: "OutputFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputOutputMappers_InputFiles_InputFileId",
                table: "InputOutputMappers");

            migrationBuilder.DropForeignKey(
                name: "FK_InputOutputMappers_OutputFiles_OutputFileId",
                table: "InputOutputMappers");

            migrationBuilder.DropIndex(
                name: "IX_InputOutputMappers_InputFileId",
                table: "InputOutputMappers");

            migrationBuilder.DropIndex(
                name: "IX_InputOutputMappers_OutputFileId",
                table: "InputOutputMappers");
        }
    }
}
