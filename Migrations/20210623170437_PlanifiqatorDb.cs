using Microsoft.EntityFrameworkCore.Migrations;

namespace Planifiqator.Migrations
{
    public partial class PlanifiqatorDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destinatii",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tara = table.Column<string>(nullable: true),
                    Regiune = table.Column<string>(nullable: true),
                    Oras = table.Column<string>(nullable: true),
                    NumeDestinatie = table.Column<string>(nullable: true),
                    Rating = table.Column<float>(nullable: false),
                    NumarRatinguri = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinatii", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recompense",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monede = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recompense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizatori",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Parola = table.Column<string>(nullable: true),
                    Monede = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizatori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notite",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizatorId = table.Column<int>(nullable: false),
                    Nume = table.Column<string>(nullable: true),
                    Continut = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notite_Utilizatori_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "Utilizatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanificariVacante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizatorId = table.Column<int>(nullable: false),
                    DestinatieId = table.Column<int>(nullable: false),
                    DataRezervare = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanificariVacante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanificariVacante_Destinatii_DestinatieId",
                        column: x => x.DestinatieId,
                        principalTable: "Destinatii",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanificariVacante_Utilizatori_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "Utilizatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UtilizatoriRecompensati",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizatorId = table.Column<int>(nullable: false),
                    RecompensaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilizatoriRecompensati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UtilizatoriRecompensati_Recompense_RecompensaId",
                        column: x => x.RecompensaId,
                        principalTable: "Recompense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UtilizatoriRecompensati_Utilizatori_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "Utilizatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notite_UtilizatorId",
                table: "Notite",
                column: "UtilizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanificariVacante_DestinatieId",
                table: "PlanificariVacante",
                column: "DestinatieId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanificariVacante_UtilizatorId",
                table: "PlanificariVacante",
                column: "UtilizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilizatoriRecompensati_RecompensaId",
                table: "UtilizatoriRecompensati",
                column: "RecompensaId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilizatoriRecompensati_UtilizatorId",
                table: "UtilizatoriRecompensati",
                column: "UtilizatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notite");

            migrationBuilder.DropTable(
                name: "PlanificariVacante");

            migrationBuilder.DropTable(
                name: "UtilizatoriRecompensati");

            migrationBuilder.DropTable(
                name: "Destinatii");

            migrationBuilder.DropTable(
                name: "Recompense");

            migrationBuilder.DropTable(
                name: "Utilizatori");
        }
    }
}
