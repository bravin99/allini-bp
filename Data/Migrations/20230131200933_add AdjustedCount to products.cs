using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace allinibp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addAdjustedCounttoproducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AdjustedCount",
                table: "Products",
                type: "double precision",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdjustedCount",
                table: "Products");
        }
    }
}
