using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameOfDronesWebApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangesOfTheGameStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Rounds");

            migrationBuilder.AddColumn<string>(
                name: "Winner",
                table: "Rounds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Player1Wins",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Player2Wins",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Winner",
                table: "Games",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Winner",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Player1Wins",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Player2Wins",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Winner",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "WinnerId",
                table: "Rounds",
                type: "int",
                nullable: true);
        }
    }
}
