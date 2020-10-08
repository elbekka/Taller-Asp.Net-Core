using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Core");

            migrationBuilder.EnsureSchema(
                name: "Masters");

            migrationBuilder.CreateTable(
                name: "TipoProgramadores",
                schema: "Masters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProgramadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programadores",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoProgramadorId = table.Column<int>(nullable: false, comment: "ID(PK) a tipo de programador"),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(maxLength: 20, nullable: false, comment: "Apellido del progrador"),
                    Edad = table.Column<int>(maxLength: 120, nullable: false),
                    DNI_NIE = table.Column<string>(maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programadores_TipoProgramadores_TipoProgramadorId",
                        column: x => x.TipoProgramadorId,
                        principalSchema: "Masters",
                        principalTable: "TipoProgramadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Tabla de programadores");

            migrationBuilder.InsertData(
                schema: "Masters",
                table: "TipoProgramadores",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Back-End" });

            migrationBuilder.InsertData(
                schema: "Masters",
                table: "TipoProgramadores",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 2, "Front-End" });

            migrationBuilder.InsertData(
                schema: "Masters",
                table: "TipoProgramadores",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 3, "Full-Stack" });

            migrationBuilder.CreateIndex(
                name: "IX_Programadores_TipoProgramadorId",
                schema: "Core",
                table: "Programadores",
                column: "TipoProgramadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programadores",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TipoProgramadores",
                schema: "Masters");
        }
    }
}
