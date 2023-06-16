using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Destino : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    PaisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.PaisId);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    ProvinciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.ProvinciaId);
                    table.ForeignKey(
                        name: "FK_Provincia_Pais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Pais",
                        principalColumn: "PaisId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    CiudadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.CiudadId);
                    table.ForeignKey(
                        name: "FK_Ciudad_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "ProvinciaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ViajeCiudades",
                columns: table => new
                {
                    ViajeCiudadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViajeId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViajeCiudades", x => x.ViajeCiudadId);
                    table.ForeignKey(
                        name: "FK_ViajeCiudades_Ciudad_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudad",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pais",
                columns: new[] { "PaisId", "Codigo", "Nombre" },
                values: new object[,]
                {
                    { 1, "Arg", "Argentina" },
                    { 2, "Br", "Brasil" },
                    { 3, "Uy", "Uruguay" }
                });

            migrationBuilder.InsertData(
                table: "Provincia",
                columns: new[] { "ProvinciaId", "Nombre", "PaisId" },
                values: new object[,]
                {
                    { 1, "Buenos Aires", 1 },
                    { 2, "Tierra del Fuego", 1 },
                    { 3, "Bahía", 2 }
                });

            migrationBuilder.InsertData(
                table: "Ciudad",
                columns: new[] { "CiudadId", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 1, "La Plata", 1 },
                    { 2, "Mar del Plata", 1 },
                    { 3, "Bahía Blanca", 1 },
                    { 4, "San Nicolás de los Arroyos", 1 },
                    { 5, "Pergamino", 1 },
                    { 6, "Tandil", 1 },
                    { 7, "Junín", 1 },
                    { 8, "Olavarría", 1 },
                    { 9, "Azul", 1 },
                    { 10, "Necochea", 1 },
                    { 11, "Zárate", 1 },
                    { 12, "Campana", 1 },
                    { 13, "Morón", 1 },
                    { 14, "Quilmes", 1 },
                    { 15, "Avellaneda", 1 },
                    { 16, "Lomas de Zamora", 1 },
                    { 17, "Lanús", 1 },
                    { 18, "San Isidro", 1 },
                    { 19, "Tigre", 1 },
                    { 20, "Vicente López", 1 },
                    { 21, "Varela", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_ProvinciaId",
                table: "Ciudad",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Provincia_PaisId",
                table: "Provincia",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_ViajeCiudades_CiudadId",
                table: "ViajeCiudades",
                column: "CiudadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ViajeCiudades");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
