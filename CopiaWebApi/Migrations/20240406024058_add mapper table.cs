using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopiaWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addmappertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InputOutputMapperId",
                table: "OutputFiles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InputOutputMapperId",
                table: "InputFiles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InputOutputMappers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InputFileId = table.Column<int>(type: "INTEGER", nullable: false),
                    OutputFileId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputOutputMappers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OutputFiles_InputOutputMapperId",
                table: "OutputFiles",
                column: "InputOutputMapperId");

            migrationBuilder.CreateIndex(
                name: "IX_InputFiles_InputOutputMapperId",
                table: "InputFiles",
                column: "InputOutputMapperId");

            migrationBuilder.AddForeignKey(
                name: "FK_InputFiles_InputOutputMappers_InputOutputMapperId",
                table: "InputFiles",
                column: "InputOutputMapperId",
                principalTable: "InputOutputMappers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputFiles_InputOutputMappers_InputOutputMapperId",
                table: "OutputFiles",
                column: "InputOutputMapperId",
                principalTable: "InputOutputMappers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputFiles_InputOutputMappers_InputOutputMapperId",
                table: "InputFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputFiles_InputOutputMappers_InputOutputMapperId",
                table: "OutputFiles");

            migrationBuilder.DropTable(
                name: "InputOutputMappers");

            migrationBuilder.DropIndex(
                name: "IX_OutputFiles_InputOutputMapperId",
                table: "OutputFiles");

            migrationBuilder.DropIndex(
                name: "IX_InputFiles_InputOutputMapperId",
                table: "InputFiles");

            migrationBuilder.DropColumn(
                name: "InputOutputMapperId",
                table: "OutputFiles");

            migrationBuilder.DropColumn(
                name: "InputOutputMapperId",
                table: "InputFiles");
        }
    }
}
