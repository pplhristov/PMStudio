using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMStudio.Data.Migrations
{
    public partial class InitialDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "CreatedOn", "DeletedOn", "IsDeleted", "ManagerId", "ModifiedOn", "Name", "Owner", "Size", "TenantId", "Type" },
                values: new object[] { 1, "100 Marguerite Ave, Unit 2, Newport Beach, CA 92660", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Newport Condo", "WestCoast Investments", 0, null, 0 });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "CreatedOn", "DeletedOn", "IsDeleted", "ManagerId", "ModifiedOn", "Name", "Owner", "Size", "TenantId", "Type" },
                values: new object[] { 2, "1822 Redhill, Irvine, Ca 92112", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Irvine Warehouse", "Logistics Solutions LLC", 0, null, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
