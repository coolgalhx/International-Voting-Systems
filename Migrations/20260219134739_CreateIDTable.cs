using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace International_Voting_Systems.Migrations
{
    /// <inheritdoc />
    public partial class CreateIDTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IDs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VoterID = table.Column<int>(type: "INTEGER", nullable: false),
                    CandidateID = table.Column<int>(type: "INTEGER", nullable: false),
                    CodeID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IDs_Candidates_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidates",
                        principalColumn: "CandidateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IDs_Codes_CodeID",
                        column: x => x.CodeID,
                        principalTable: "Codes",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IDs_Voters_VoterID",
                        column: x => x.VoterID,
                        principalTable: "Voters",
                        principalColumn: "VoterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IDs_CandidateID",
                table: "IDs",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_IDs_CodeID",
                table: "IDs",
                column: "CodeID");

            migrationBuilder.CreateIndex(
                name: "IX_IDs_VoterID",
                table: "IDs",
                column: "VoterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IDs");
        }
    }
}
