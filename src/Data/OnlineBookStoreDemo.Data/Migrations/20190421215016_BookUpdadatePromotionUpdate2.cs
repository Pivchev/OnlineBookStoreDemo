using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookStoreDemo.Data.Migrations
{
    public partial class BookUpdadatePromotionUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromotionPercentige",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "PromotionPercentage",
                table: "Books",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromotionPercentage",
                table: "Books");

            migrationBuilder.AddColumn<float>(
                name: "PromotionPercentige",
                table: "Books",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
