using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace turnos.Migrations
{
    public partial class migracionentidadAnalisisFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DNI = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    FechaNac = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    Direccion = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.IdPaciente);
                });

            migrationBuilder.CreateTable(
                name: "Practica",
                columns: table => new
                {
                    IdPractica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    NombrePractica = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practica", x => x.IdPractica);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    IdOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroOrden = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IdPaciente = table.Column<int>(type: "int", unicode: false, nullable: false),
                    IdPractica = table.Column<int>(type: "int", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.IdOrden);
                    table.ForeignKey(
                        name: "FK_Orden_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_Practica_IdPractica",
                        column: x => x.IdPractica,
                        principalTable: "Practica",
                        principalColumn: "IdPractica",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenDeTrabajo",
                columns: table => new
                {
                    IdOrdenDeTrabajo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValoresDePractica = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    IdOrden = table.Column<int>(type: "int", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDeTrabajo", x => x.IdOrdenDeTrabajo);
                    table.ForeignKey(
                        name: "FK_OrdenDeTrabajo_Orden_IdOrden",
                        column: x => x.IdOrden,
                        principalTable: "Orden",
                        principalColumn: "IdOrden",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnalisisFinal",
                columns: table => new
                {
                    IdAnalisisFinal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IdOrdenDeTrabajo = table.Column<int>(type: "int", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisisFinal", x => x.IdAnalisisFinal);
                    table.ForeignKey(
                        name: "FK_AnalisisFinal_OrdenDeTrabajo_IdOrdenDeTrabajo",
                        column: x => x.IdOrdenDeTrabajo,
                        principalTable: "OrdenDeTrabajo",
                        principalColumn: "IdOrdenDeTrabajo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalisisFinal_IdOrdenDeTrabajo",
                table: "AnalisisFinal",
                column: "IdOrdenDeTrabajo");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_IdPaciente",
                table: "Orden",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_IdPractica",
                table: "Orden",
                column: "IdPractica");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeTrabajo_IdOrden",
                table: "OrdenDeTrabajo",
                column: "IdOrden");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalisisFinal");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "OrdenDeTrabajo");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Practica");
        }
    }
}
