using Microsoft.EntityFrameworkCore.Migrations;

namespace PMStudio.Data.Migrations
{
    public partial class ImplemntingManagerRoleOnTenants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "Tenants",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ManagerId",
                table: "Tenants",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_AspNetUsers_ManagerId",
                table: "Tenants",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_AspNetUsers_ManagerId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_ManagerId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Tenants");
        }
    }
}
