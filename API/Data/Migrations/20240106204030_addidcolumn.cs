using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieAPI.Data.Migrations
{
    public partial class addidcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "Movies",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Movies",
                newName: "Guid");
        }
    }
}
