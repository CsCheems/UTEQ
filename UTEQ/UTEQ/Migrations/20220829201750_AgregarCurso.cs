using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UTEQ.Migrations
{
    public partial class AgregarCurso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombrecurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    horario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipomodalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lugar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totalhoras = table.Column<float>(type: "real", nullable: false),
                    costo = table.Column<float>(type: "real", nullable: false),
                    costopref = table.Column<float>(type: "real", nullable: false),
                    urltemario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    requisitos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    criterioeval = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModalidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursos_Modalidad_ModalidadId",
                        column: x => x.ModalidadId,
                        principalTable: "Modalidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_ModalidadId",
                table: "Cursos",
                column: "ModalidadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
