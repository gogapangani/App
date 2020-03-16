using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvertisementsApi.Migrations
{
    public partial class imgPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Advertisement");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Advertisement",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Advertisement");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Advertisement",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
