using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace allinibp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpadateCategoriesandaddIdentityRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Display",
                table: "Categories",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Display",
                table: "Categories");
        }
    }
}
