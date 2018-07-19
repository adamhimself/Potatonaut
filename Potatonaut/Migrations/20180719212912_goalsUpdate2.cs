using Microsoft.EntityFrameworkCore.Migrations;

namespace Potatonaut.Migrations
{
    public partial class goalsUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_AspNetUsers_AppUserId1",
                table: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_Goals_AppUserId1",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Goals");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Goals",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Goals_AppUserId",
                table: "Goals",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_AspNetUsers_AppUserId",
                table: "Goals",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_AspNetUsers_AppUserId",
                table: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_Goals_AppUserId",
                table: "Goals");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Goals",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Goals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Goals_AppUserId1",
                table: "Goals",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_AspNetUsers_AppUserId1",
                table: "Goals",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
