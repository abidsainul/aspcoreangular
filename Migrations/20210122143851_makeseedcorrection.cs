using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnetcore_spa.Migrations
{
    public partial class makeseedcorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Make1-ModelB");

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Make2-ModelB");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Make1-ModelA");

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Make2-ModelA");
        }
    }
}
