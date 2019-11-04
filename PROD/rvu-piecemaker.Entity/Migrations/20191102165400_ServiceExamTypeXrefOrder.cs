using Microsoft.EntityFrameworkCore.Migrations;

namespace RvuPiecemaker.Entity.Migrations
{
    public partial class ServiceExamTypeXrefOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                schema: "Common",
                table: "ServiceExamType_xref",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                schema: "Common",
                table: "ServiceExamType_xref");
        }
    }
}
