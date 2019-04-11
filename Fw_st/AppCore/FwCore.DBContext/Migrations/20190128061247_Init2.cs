using Microsoft.EntityFrameworkCore.Migrations;

namespace FwCore.DBContext.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pBrand_pCategory_CategoryID",
                table: "pBrand");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "pBrand",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_pBrand_pCategory_CategoryID",
                table: "pBrand",
                column: "CategoryID",
                principalTable: "pCategory",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pBrand_pCategory_CategoryID",
                table: "pBrand");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "pBrand",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_pBrand_pCategory_CategoryID",
                table: "pBrand",
                column: "CategoryID",
                principalTable: "pCategory",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
