using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace International_Voting_Systems.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Voters");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Voters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
