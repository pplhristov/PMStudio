using Microsoft.EntityFrameworkCore.Migrations;

namespace PMStudio.Data.Migrations
{
    public partial class UpdateTenantToPropertyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "Tenants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_PropertyId",
                table: "Tenants",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Properties_PropertyId",
                table: "Tenants",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Properties_PropertyId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_PropertyId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Tenants");
        }
    }
}
