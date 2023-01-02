using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiGranjitaParaiso.Migrations
{
    /// <inheritdoc />
    public partial class AddNullabletoFileItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemFiles_Files_FileId",
                table: "ItemFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemFiles_Items_ItemId",
                table: "ItemFiles");

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                table: "ItemFiles",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "FileId",
                table: "ItemFiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemFiles_Files_FileId",
                table: "ItemFiles",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemFiles_Items_ItemId",
                table: "ItemFiles",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemFiles_Files_FileId",
                table: "ItemFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemFiles_Items_ItemId",
                table: "ItemFiles");

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                table: "ItemFiles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FileId",
                table: "ItemFiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemFiles_Files_FileId",
                table: "ItemFiles",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemFiles_Items_ItemId",
                table: "ItemFiles",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
