using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Promptito.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromptTema");

            migrationBuilder.CreateTable(
                name: "PromptTematica",
                columns: table => new
                {
                    ListaPromptsId = table.Column<int>(type: "integer", nullable: false),
                    ListaTematicasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromptTematica", x => new { x.ListaPromptsId, x.ListaTematicasId });
                    table.ForeignKey(
                        name: "FK_PromptTematica_Temas_ListaTematicasId",
                        column: x => x.ListaTematicasId,
                        principalTable: "Temas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromptTematica_prompt_ListaPromptsId",
                        column: x => x.ListaPromptsId,
                        principalTable: "prompt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromptTematica_ListaTematicasId",
                table: "PromptTematica",
                column: "ListaTematicasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromptTematica");

            migrationBuilder.CreateTable(
                name: "PromptTema",
                columns: table => new
                {
                    ListaPromptsId = table.Column<int>(type: "integer", nullable: false),
                    ListaTematicasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromptTema", x => new { x.ListaPromptsId, x.ListaTematicasId });
                    table.ForeignKey(
                        name: "FK_PromptTema_Temas_ListaTematicasId",
                        column: x => x.ListaTematicasId,
                        principalTable: "Temas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromptTema_prompt_ListaPromptsId",
                        column: x => x.ListaPromptsId,
                        principalTable: "prompt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromptTema_ListaTematicasId",
                table: "PromptTema",
                column: "ListaTematicasId");
        }
    }
}
