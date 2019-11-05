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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Visita",
                columns: new[] { "Id", "Celular", "Comentario", "Correo", "Motivo", "Nombre" },
                values: new object[,]
                {
                    { 1, 3163534451L, null, "cristiancamilo10_95@outlook.com", 2, "Cristian Bonilla" },
                    { 2, 3201198827L, "Productos exclusivos de fragancia VIP Carolina Herrera", "jessea_19av@gmail.com", 1, "Jessica Gutierrez" },
                    { 3, 3192550012L, null, "luz.andre881@gmail.com", 3, "Luz Andrea Ramos" },
                    { 4, 3227179901L, null, "sandrylozano89@hotmail.com", 1, "Sandra Lozano" },
                    { 5, 31477810911L, "Ropa de gran calidad y al mejor costo", "santi87.giraldo@gmail.com", 2, "Felipe Santiago Giraldo" }
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
