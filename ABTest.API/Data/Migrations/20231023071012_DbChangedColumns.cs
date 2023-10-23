using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABTest.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class DbChangedColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Experiments_ExperimentId",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experiments",
                table: "Experiments");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ExperimentId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Experiments");

            migrationBuilder.DropColumn(
                name: "ExperimentId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Experiments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExperimentToken",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experiments",
                table: "Experiments",
                column: "Token");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ExperimentToken",
                table: "Clients",
                column: "ExperimentToken");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Experiments_ExperimentToken",
                table: "Clients",
                column: "ExperimentToken",
                principalTable: "Experiments",
                principalColumn: "Token",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Experiments_ExperimentToken",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experiments",
                table: "Experiments");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ExperimentToken",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Experiments");

            migrationBuilder.DropColumn(
                name: "ExperimentToken",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Experiments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ExperimentId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experiments",
                table: "Experiments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ExperimentId",
                table: "Clients",
                column: "ExperimentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Experiments_ExperimentId",
                table: "Clients",
                column: "ExperimentId",
                principalTable: "Experiments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
