using Microsoft.EntityFrameworkCore.Migrations;

namespace csd412_final.Migrations.ApplicationDb
{
    public partial class CardCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollectionID",
                table: "Notecards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CollectionID",
                table: "Notecards");
        }
    }
}
