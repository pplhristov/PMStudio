using Microsoft.EntityFrameworkCore.Migrations;

namespace PMStudio.Data.Migrations
{
    public partial class AddMaintenanceServiceController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "MaintenanceServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServices_VendorId",
                table: "MaintenanceServices",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceServices_Vendors_VendorId",
                table: "MaintenanceServices",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceServices_Vendors_VendorId",
                table: "MaintenanceServices");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceServices_VendorId",
                table: "MaintenanceServices");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "MaintenanceServices");
        }
    }
}
