using Microsoft.EntityFrameworkCore.Migrations;

namespace EfDataAccess.Migrations
{
    public partial class altertables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Automobili_Modeli_ModelId",
                table: "Automobili");

            migrationBuilder.AddColumn<int>(
                name: "MarkaId",
                table: "Modeli",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ModelId",
                table: "Automobili",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Modeli_MarkaId",
                table: "Modeli",
                column: "MarkaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Automobili_Modeli_ModelId",
                table: "Automobili",
                column: "ModelId",
                principalTable: "Modeli",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Modeli_Marke_MarkaId",
                table: "Modeli",
                column: "MarkaId",
                principalTable: "Marke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Automobili_Modeli_ModelId",
                table: "Automobili");

            migrationBuilder.DropForeignKey(
                name: "FK_Modeli_Marke_MarkaId",
                table: "Modeli");

            migrationBuilder.DropIndex(
                name: "IX_Modeli_MarkaId",
                table: "Modeli");

            migrationBuilder.DropColumn(
                name: "MarkaId",
                table: "Modeli");

            migrationBuilder.AlterColumn<int>(
                name: "ModelId",
                table: "Automobili",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Automobili_Modeli_ModelId",
                table: "Automobili",
                column: "ModelId",
                principalTable: "Modeli",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
