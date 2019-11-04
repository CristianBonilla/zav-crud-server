using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud.Domain.Migrations
{
    public partial class CreateDefinition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Visita",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Correo = table.Column<string>(maxLength: 150, nullable: false),
                    Celular = table.Column<long>(nullable: false),
                    Motivo = table.Column<int>(nullable: false),
                    Comentario = table.Column<string>(type: "varchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visita", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visita",
                schema: "dbo");
        }
    }
}
