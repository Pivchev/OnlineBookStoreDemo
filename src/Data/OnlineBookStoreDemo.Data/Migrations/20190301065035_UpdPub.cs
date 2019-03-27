using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookStoreDemo.Data.Migrations
{
    public partial class UpdPub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublisherID",
                table: "Publishers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublisherID",
                table: "Publishers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
