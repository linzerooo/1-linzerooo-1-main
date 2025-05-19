using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finate.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class JobFormTableCreate_CreateManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_CandidateForms_CandidateFormId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_JobFormDescriptionParts_JobForms_JobFormId",
                table: "JobFormDescriptionParts");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_CandidateForms_CandidateFormId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_JobForms_JobFormId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_CandidateForms_CandidateFormId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_JobForms_JobFormId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLanguages_CandidateForms_CandidateFormId",
                table: "UserLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLanguages_JobForms_JobFormId",
                table: "UserLanguages");

            migrationBuilder.DropTable(
                name: "CandidateForms");

            migrationBuilder.DropTable(
                name: "JobForms");

            migrationBuilder.DropIndex(
                name: "IX_UserLanguages_CandidateFormId",
                table: "UserLanguages");

            migrationBuilder.DropIndex(
                name: "IX_UserLanguages_JobFormId",
                table: "UserLanguages");

            migrationBuilder.DropIndex(
                name: "IX_Tags_CandidateFormId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_JobFormId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Skills_CandidateFormId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_JobFormId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CandidateFormId",
                table: "UserLanguages");

            migrationBuilder.DropColumn(
                name: "JobFormId",
                table: "UserLanguages");

            migrationBuilder.DropColumn(
                name: "CandidateFormId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "JobFormId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CandidateFormId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "JobFormId",
                table: "Skills");

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfessionName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    PlaceAddress = table.Column<string>(type: "text", nullable: false),
                    Salary = table.Column<int>(type: "integer", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: true),
                    Rating = table.Column<double>(type: "double precision", nullable: false),
                    IsBlocked = table.Column<bool>(type: "boolean", nullable: false),
                    Views = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forms_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateFormExtensions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FormId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsClosed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateFormExtensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateFormExtensions_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormSkill",
                columns: table => new
                {
                    FormsId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormSkill", x => new { x.FormsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_FormSkill_Forms_FormsId",
                        column: x => x.FormsId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormTag",
                columns: table => new
                {
                    FormsId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormTag", x => new { x.FormsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_FormTag_Forms_FormsId",
                        column: x => x.FormsId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormUserLanguage",
                columns: table => new
                {
                    FormsId = table.Column<Guid>(type: "uuid", nullable: false),
                    LanguagesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormUserLanguage", x => new { x.FormsId, x.LanguagesId });
                    table.ForeignKey(
                        name: "FK_FormUserLanguage_Forms_FormsId",
                        column: x => x.FormsId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormUserLanguage_UserLanguages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "UserLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobFormExtensions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FormId = table.Column<Guid>(type: "uuid", nullable: false),
                    Statement = table.Column<string>(type: "text", nullable: true),
                    JobType = table.Column<int>(type: "integer", nullable: false),
                    Applied = table.Column<int>(type: "integer", nullable: false),
                    ApplicationEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobFormExtensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobFormExtensions_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateFormExtensions_FormId",
                table: "CandidateFormExtensions",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_IsActive",
                table: "Forms",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_ProfessionName",
                table: "Forms",
                column: "ProfessionName");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_Rating",
                table: "Forms",
                column: "Rating");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_UserId",
                table: "Forms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FormSkill_SkillsId",
                table: "FormSkill",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_FormTag_TagsId",
                table: "FormTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_FormUserLanguage_LanguagesId",
                table: "FormUserLanguage",
                column: "LanguagesId");

            migrationBuilder.CreateIndex(
                name: "IX_JobFormExtensions_FormId",
                table: "JobFormExtensions",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_CandidateFormExtensions_CandidateFormId",
                table: "Experiences",
                column: "CandidateFormId",
                principalTable: "CandidateFormExtensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobFormDescriptionParts_JobFormExtensions_JobFormId",
                table: "JobFormDescriptionParts",
                column: "JobFormId",
                principalTable: "JobFormExtensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_CandidateFormExtensions_CandidateFormId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_JobFormDescriptionParts_JobFormExtensions_JobFormId",
                table: "JobFormDescriptionParts");

            migrationBuilder.DropTable(
                name: "CandidateFormExtensions");

            migrationBuilder.DropTable(
                name: "FormSkill");

            migrationBuilder.DropTable(
                name: "FormTag");

            migrationBuilder.DropTable(
                name: "FormUserLanguage");

            migrationBuilder.DropTable(
                name: "JobFormExtensions");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateFormId",
                table: "UserLanguages",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "JobFormId",
                table: "UserLanguages",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateFormId",
                table: "Tags",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "JobFormId",
                table: "Tags",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateFormId",
                table: "Skills",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "JobFormId",
                table: "Skills",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CandidateForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsBlocked = table.Column<bool>(type: "boolean", nullable: false),
                    IsClosed = table.Column<bool>(type: "boolean", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: true),
                    PlaceAddress = table.Column<string>(type: "text", nullable: false),
                    ProfessionName = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: false),
                    Salary = table.Column<int>(type: "integer", nullable: false),
                    Views = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateForms_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicationEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Applied = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsBlocked = table.Column<bool>(type: "boolean", nullable: false),
                    JobType = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: true),
                    PlaceAddress = table.Column<string>(type: "text", nullable: false),
                    ProfessionName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: false),
                    Salary = table.Column<int>(type: "integer", nullable: false),
                    Statement = table.Column<string>(type: "text", nullable: true),
                    Views = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobForms_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguages_CandidateFormId",
                table: "UserLanguages",
                column: "CandidateFormId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguages_JobFormId",
                table: "UserLanguages",
                column: "JobFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_CandidateFormId",
                table: "Tags",
                column: "CandidateFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_JobFormId",
                table: "Tags",
                column: "JobFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CandidateFormId",
                table: "Skills",
                column: "CandidateFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_JobFormId",
                table: "Skills",
                column: "JobFormId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateForms_ProfessionName",
                table: "CandidateForms",
                column: "ProfessionName");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateForms_Rating",
                table: "CandidateForms",
                column: "Rating");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateForms_UserId",
                table: "CandidateForms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobForms_IsActive",
                table: "JobForms",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_JobForms_ProfessionName",
                table: "JobForms",
                column: "ProfessionName");

            migrationBuilder.CreateIndex(
                name: "IX_JobForms_Rating",
                table: "JobForms",
                column: "Rating");

            migrationBuilder.CreateIndex(
                name: "IX_JobForms_UserId",
                table: "JobForms",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_CandidateForms_CandidateFormId",
                table: "Experiences",
                column: "CandidateFormId",
                principalTable: "CandidateForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobFormDescriptionParts_JobForms_JobFormId",
                table: "JobFormDescriptionParts",
                column: "JobFormId",
                principalTable: "JobForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_CandidateForms_CandidateFormId",
                table: "Skills",
                column: "CandidateFormId",
                principalTable: "CandidateForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_JobForms_JobFormId",
                table: "Skills",
                column: "JobFormId",
                principalTable: "JobForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_CandidateForms_CandidateFormId",
                table: "Tags",
                column: "CandidateFormId",
                principalTable: "CandidateForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_JobForms_JobFormId",
                table: "Tags",
                column: "JobFormId",
                principalTable: "JobForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLanguages_CandidateForms_CandidateFormId",
                table: "UserLanguages",
                column: "CandidateFormId",
                principalTable: "CandidateForms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLanguages_JobForms_JobFormId",
                table: "UserLanguages",
                column: "JobFormId",
                principalTable: "JobForms",
                principalColumn: "Id");
        }
    }
}
