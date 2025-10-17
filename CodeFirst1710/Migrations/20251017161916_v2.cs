using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst1710.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TvcSan_Pham_TvcLoai_San_Pham_tvcLoai_San_PhamtvcId",
                table: "TvcSan_Pham");

            migrationBuilder.AlterColumn<long>(
                name: "tvcLoai_San_PhamtvcId",
                table: "TvcSan_Pham",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_TvcSan_Pham_TvcLoai_San_Pham_tvcLoai_San_PhamtvcId",
                table: "TvcSan_Pham",
                column: "tvcLoai_San_PhamtvcId",
                principalTable: "TvcLoai_San_Pham",
                principalColumn: "tvcId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TvcSan_Pham_TvcLoai_San_Pham_tvcLoai_San_PhamtvcId",
                table: "TvcSan_Pham");

            migrationBuilder.AlterColumn<long>(
                name: "tvcLoai_San_PhamtvcId",
                table: "TvcSan_Pham",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TvcSan_Pham_TvcLoai_San_Pham_tvcLoai_San_PhamtvcId",
                table: "TvcSan_Pham",
                column: "tvcLoai_San_PhamtvcId",
                principalTable: "TvcLoai_San_Pham",
                principalColumn: "tvcId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
