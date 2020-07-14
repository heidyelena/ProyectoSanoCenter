using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoSanoCenter.Data.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dni",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntrenadorId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Localidad",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Ejercicio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEjercicio = table.Column<string>(nullable: true),
                    Demostracion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejercicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gimnasio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreGimnasio = table.Column<string>(nullable: true),
                    DireccionGimnasio = table.Column<string>(nullable: true),
                    LocalidadGimnasio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gimnasio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entrenador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Foto = table.Column<string>(nullable: true),
                    NombreEntrenador = table.Column<string>(nullable: true),
                    ApellidoEntrenador = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Especialidad = table.Column<string>(nullable: true),
                    GimnasioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrenador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entrenador_Gimnasio_GimnasioId",
                        column: x => x.GimnasioId,
                        principalTable: "Gimnasio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(nullable: true),
                    NombreReto = table.Column<string>(nullable: true),
                    Dificultad = table.Column<string>(nullable: true),
                    Series = table.Column<string>(nullable: true),
                    Repeticiones = table.Column<string>(nullable: true),
                    FechaLimite = table.Column<DateTime>(nullable: false),
                    EntrenadorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reto_Entrenador_EntrenadorId",
                        column: x => x.EntrenadorId,
                        principalTable: "Entrenador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EjercicioReto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetoId = table.Column<int>(nullable: false),
                    EjercicioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EjercicioReto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EjercicioReto_Ejercicio_EjercicioId",
                        column: x => x.EjercicioId,
                        principalTable: "Ejercicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EjercicioReto_Reto_RetoId",
                        column: x => x.RetoId,
                        principalTable: "Reto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ranking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetoId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ranking_Reto_RetoId",
                        column: x => x.RetoId,
                        principalTable: "Reto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ranking_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valoracion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Puntuacion = table.Column<int>(nullable: false),
                    NumeroPuntuaciones = table.Column<int>(nullable: false),
                    MediaPuntuaciones = table.Column<double>(nullable: false),
                    RetoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valoracion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Valoracion_Reto_RetoId",
                        column: x => x.RetoId,
                        principalTable: "Reto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EntrenadorId",
                table: "AspNetUsers",
                column: "EntrenadorId");

            migrationBuilder.CreateIndex(
                name: "IX_EjercicioReto_EjercicioId",
                table: "EjercicioReto",
                column: "EjercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_EjercicioReto_RetoId",
                table: "EjercicioReto",
                column: "RetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrenador_GimnasioId",
                table: "Entrenador",
                column: "GimnasioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_RetoId",
                table: "Ranking",
                column: "RetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_UsuarioId",
                table: "Ranking",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reto_EntrenadorId",
                table: "Reto",
                column: "EntrenadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Valoracion_RetoId",
                table: "Valoracion",
                column: "RetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Entrenador_EntrenadorId",
                table: "AspNetUsers",
                column: "EntrenadorId",
                principalTable: "Entrenador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Entrenador_EntrenadorId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EjercicioReto");

            migrationBuilder.DropTable(
                name: "Ranking");

            migrationBuilder.DropTable(
                name: "Valoracion");

            migrationBuilder.DropTable(
                name: "Ejercicio");

            migrationBuilder.DropTable(
                name: "Reto");

            migrationBuilder.DropTable(
                name: "Entrenador");

            migrationBuilder.DropTable(
                name: "Gimnasio");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EntrenadorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Dni",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EntrenadorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Localidad",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "AspNetUsers");
        }
    }
}
