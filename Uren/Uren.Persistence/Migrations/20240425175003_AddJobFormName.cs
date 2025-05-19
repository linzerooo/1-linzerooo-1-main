using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finate.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddJobFormName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateFormExtensions_Forms_FormId",
                table: "CandidateFormExtensions");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Forms");

            migrationBuilder.RenameColumn(
                name: "FormId",
                table: "CandidateFormExtensions",
                newName: "CandidateFormId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateFormExtensions_FormId",
                table: "CandidateFormExtensions",
                newName: "IX_CandidateFormExtensions_CandidateFormId");

            migrationBuilder.AddColumn<string>(
                name: "JobFormName",
                table: "JobFormExtensions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateFormExtensions_Forms_CandidateFormId",
                table: "CandidateFormExtensions",
                column: "CandidateFormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateFormExtensions_Forms_CandidateFormId",
                table: "CandidateFormExtensions");

            migrationBuilder.DropColumn(
                name: "JobFormName",
                table: "JobFormExtensions");

            migrationBuilder.RenameColumn(
                name: "CandidateFormId",
                table: "CandidateFormExtensions",
                newName: "FormId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateFormExtensions_CandidateFormId",
                table: "CandidateFormExtensions",
                newName: "IX_CandidateFormExtensions_FormId");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Forms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateFormExtensions_Forms_FormId",
                table: "CandidateFormExtensions",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
