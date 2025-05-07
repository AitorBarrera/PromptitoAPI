using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Promptito.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colecciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colecciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Llms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Llms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Temas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
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
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prompts",
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
                    table.PrimaryKey("PK_Prompts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prompts_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColeccionPrompt",
                columns: table => new
                {
                    ListaColeccionesId = table.Column<int>(type: "integer", nullable: false),
                    ListaPromptsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColeccionPrompt", x => new { x.ListaColeccionesId, x.ListaPromptsId });
                    table.ForeignKey(
                        name: "FK_ColeccionPrompt_Colecciones_ListaColeccionesId",
                        column: x => x.ListaColeccionesId,
                        principalTable: "Colecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColeccionPrompt_Prompts_ListaPromptsId",
                        column: x => x.ListaPromptsId,
                        principalTable: "Prompts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LlmPrompt",
                columns: table => new
                {
                    ListaLlmsId = table.Column<int>(type: "integer", nullable: false),
                    ListaPromptsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LlmPrompt", x => new { x.ListaLlmsId, x.ListaPromptsId });
                    table.ForeignKey(
                        name: "FK_LlmPrompt_Llms_ListaLlmsId",
                        column: x => x.ListaLlmsId,
                        principalTable: "Llms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LlmPrompt_Prompts_ListaPromptsId",
                        column: x => x.ListaPromptsId,
                        principalTable: "Prompts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromptTema",
                columns: table => new
                {
                    ListaPromptsId = table.Column<int>(type: "integer", nullable: false),
                    ListaTemasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromptTema", x => new { x.ListaPromptsId, x.ListaTemasId });
                    table.ForeignKey(
                        name: "FK_PromptTema_Prompts_ListaPromptsId",
                        column: x => x.ListaPromptsId,
                        principalTable: "Prompts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromptTema_Temas_ListaTemasId",
                        column: x => x.ListaTemasId,
                        principalTable: "Temas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromptUsuario",
                columns: table => new
                {
                    ListaPromptsFavoritosId = table.Column<int>(type: "integer", nullable: false),
                    ListaUsuariosEnFavoritosId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromptUsuario", x => new { x.ListaPromptsFavoritosId, x.ListaUsuariosEnFavoritosId });
                    table.ForeignKey(
                        name: "FK_PromptUsuario_Prompts_ListaPromptsFavoritosId",
                        column: x => x.ListaPromptsFavoritosId,
                        principalTable: "Prompts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromptUsuario_Usuarios_ListaUsuariosEnFavoritosId",
                        column: x => x.ListaUsuariosEnFavoritosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColeccionPrompt_ListaPromptsId",
                table: "ColeccionPrompt",
                column: "ListaPromptsId");

            migrationBuilder.CreateIndex(
                name: "IX_LlmPrompt_ListaPromptsId",
                table: "LlmPrompt",
                column: "ListaPromptsId");

            migrationBuilder.CreateIndex(
                name: "IX_Prompts_UsuarioId",
                table: "Prompts",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PromptTema_ListaTemasId",
                table: "PromptTema",
                column: "ListaTemasId");

            migrationBuilder.CreateIndex(
                name: "IX_PromptUsuario_ListaUsuariosEnFavoritosId",
                table: "PromptUsuario",
                column: "ListaUsuariosEnFavoritosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColeccionPrompt");

            migrationBuilder.DropTable(
                name: "LlmPrompt");

            migrationBuilder.DropTable(
                name: "PromptTema");

            migrationBuilder.DropTable(
                name: "PromptUsuario");

            migrationBuilder.DropTable(
                name: "Colecciones");

            migrationBuilder.DropTable(
                name: "Llms");

            migrationBuilder.DropTable(
                name: "Temas");

            migrationBuilder.DropTable(
                name: "Prompts");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
