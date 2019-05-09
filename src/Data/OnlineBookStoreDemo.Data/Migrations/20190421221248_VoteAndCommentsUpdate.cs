using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookStoreDemo.Data.Migrations
{
    public partial class VoteAndCommentsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_AspNetUsers_UserId1",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_UserId1",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Votes");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Votes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UserId",
                table: "Votes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_AspNetUsers_UserId",
                table: "Votes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_AspNetUsers_UserId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_UserId",
                table: "Votes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Votes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Votes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UserId1",
                table: "Votes",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_AspNetUsers_UserId1",
                table: "Votes",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
