using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Promptito.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "v2");

            migrationBuilder.CreateTable(
                name: "coleccion",
                schema: "v2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coleccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "llm",
                schema: "v2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_llm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tematica",
                schema: "v2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tematica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                schema: "v2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    AvatarUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "prompt",
                schema: "v2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    TextoContenido = table.Column<string>(type: "text", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prompt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prompt_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "v2",
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColeccionPrompt",
                schema: "v2",
                columns: table => new
                {
                    ListaColeccionesId = table.Column<int>(type: "integer", nullable: false),
                    ListaPromptsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColeccionPrompt", x => new { x.ListaColeccionesId, x.ListaPromptsId });
                    table.ForeignKey(
                        name: "FK_ColeccionPrompt_coleccion_ListaColeccionesId",
                        column: x => x.ListaColeccionesId,
                        principalSchema: "v2",
                        principalTable: "coleccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColeccionPrompt_prompt_ListaPromptsId",
                        column: x => x.ListaPromptsId,
                        principalSchema: "v2",
                        principalTable: "prompt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LlmPrompt",
                schema: "v2",
                columns: table => new
                {
                    ListaLlmsId = table.Column<int>(type: "integer", nullable: false),
                    ListaPromptsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LlmPrompt", x => new { x.ListaLlmsId, x.ListaPromptsId });
                    table.ForeignKey(
                        name: "FK_LlmPrompt_llm_ListaLlmsId",
                        column: x => x.ListaLlmsId,
                        principalSchema: "v2",
                        principalTable: "llm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LlmPrompt_prompt_ListaPromptsId",
                        column: x => x.ListaPromptsId,
                        principalSchema: "v2",
                        principalTable: "prompt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromptTematica",
                schema: "v2",
                columns: table => new
                {
                    ListaPromptsId = table.Column<int>(type: "integer", nullable: false),
                    ListaTematicasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromptTematica", x => new { x.ListaPromptsId, x.ListaTematicasId });
                    table.ForeignKey(
                        name: "FK_PromptTematica_prompt_ListaPromptsId",
                        column: x => x.ListaPromptsId,
                        principalSchema: "v2",
                        principalTable: "prompt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromptTematica_tematica_ListaTematicasId",
                        column: x => x.ListaTematicasId,
                        principalSchema: "v2",
                        principalTable: "tematica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromptUsuario",
                schema: "v2",
                columns: table => new
                {
                    ListaPromptsFavoritosId = table.Column<int>(type: "integer", nullable: false),
                    ListaUsuariosEnFavoritosId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromptUsuario", x => new { x.ListaPromptsFavoritosId, x.ListaUsuariosEnFavoritosId });
                    table.ForeignKey(
                        name: "FK_PromptUsuario_prompt_ListaPromptsFavoritosId",
                        column: x => x.ListaPromptsFavoritosId,
                        principalSchema: "v2",
                        principalTable: "prompt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromptUsuario_usuario_ListaUsuariosEnFavoritosId",
                        column: x => x.ListaUsuariosEnFavoritosId,
                        principalSchema: "v2",
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColeccionPrompt_ListaPromptsId",
                schema: "v2",
                table: "ColeccionPrompt",
                column: "ListaPromptsId");

            migrationBuilder.CreateIndex(
                name: "IX_llm_Nombre_Version",
                schema: "v2",
                table: "llm",
                columns: new[] { "Nombre", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LlmPrompt_ListaPromptsId",
                schema: "v2",
                table: "LlmPrompt",
                column: "ListaPromptsId");

            migrationBuilder.CreateIndex(
                name: "IX_prompt_UsuarioId",
                schema: "v2",
                table: "prompt",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PromptTematica_ListaTematicasId",
                schema: "v2",
                table: "PromptTematica",
                column: "ListaTematicasId");

            migrationBuilder.CreateIndex(
                name: "IX_PromptUsuario_ListaUsuariosEnFavoritosId",
                schema: "v2",
                table: "PromptUsuario",
                column: "ListaUsuariosEnFavoritosId");

            migrationBuilder.CreateIndex(
                name: "IX_tematica_Nombre",
                schema: "v2",
                table: "tematica",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_Email",
                schema: "v2",
                table: "usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_Nombre",
                schema: "v2",
                table: "usuario",
                column: "Nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColeccionPrompt",
                schema: "v2");

            migrationBuilder.DropTable(
                name: "LlmPrompt",
                schema: "v2");

            migrationBuilder.DropTable(
                name: "PromptTematica",
                schema: "v2");

            migrationBuilder.DropTable(
                name: "PromptUsuario",
                schema: "v2");

            migrationBuilder.DropTable(
                name: "coleccion",
                schema: "v2");

            migrationBuilder.DropTable(
                name: "llm",
                schema: "v2");

            migrationBuilder.DropTable(
                name: "tematica",
                schema: "v2");

            migrationBuilder.DropTable(
                name: "prompt",
                schema: "v2");

            migrationBuilder.DropTable(
                name: "usuario",
                schema: "v2");
        }
    }
}
