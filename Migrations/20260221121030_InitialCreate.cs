using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace International_Voting_Systems.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CandidateID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CandidateFullName = table.Column<string>(type: "TEXT", nullable: false),
                    CandidateEmail = table.Column<string>(type: "TEXT", nullable: false),
                    CandidateAddress = table.Column<string>(type: "TEXT", nullable: false),
                    CandidateDOB = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    CandidateCity = table.Column<string>(type: "TEXT", nullable: false),
                    CandidateNationalInsuranceNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CandidateConstituency = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.CandidateID);
                });

            migrationBuilder.CreateTable(
                name: "Voters",
                columns: table => new
                {
                    VoterID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    DOB = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ContactNumber = table.Column<double>(type: "REAL", nullable: false),
                    PostCode = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsSuspended = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voters", x => x.VoterID);
                });

            migrationBuilder.CreateTable(
                name: "Codes",
                columns: table => new
                {
                    CodeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VoterID = table.Column<int>(type: "INTEGER", nullable: false),
                    OTP = table.Column<int>(type: "INTEGER", nullable: false),
                    ExpiryTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsUsed = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codes", x => x.CodeID);
                    table.ForeignKey(
                        name: "FK_Codes_Voters_VoterID",
                        column: x => x.VoterID,
                        principalTable: "Voters",
                        principalColumn: "VoterID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Codes_VoterID",
                table: "Codes",
                column: "VoterID");

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

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Codes");

            migrationBuilder.DropTable(
                name: "Voters");
        }
    }
}
