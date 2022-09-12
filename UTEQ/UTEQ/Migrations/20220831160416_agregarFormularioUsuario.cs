using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UTEQ.Migrations
{
    public partial class agregarFormularioUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "FormularioUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    whats = table.Column<int>(type: "int", nullable: false),
                    otroTelefono = table.Column<int>(type: "int", nullable: false),
                    egresado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    egresadoMod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carrera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estudiante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    docente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    publico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sugerencia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormularioUsuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormularioUsuario");

           
        }
    }
}
