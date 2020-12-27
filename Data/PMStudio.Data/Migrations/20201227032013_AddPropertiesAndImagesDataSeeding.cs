using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMStudio.Data.Migrations
{
    public partial class AddPropertiesAndImagesDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "088bbcf3-2259-4570-93b8-cffbf7a064e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bd74cf5-a8f0-4860-8799-6733eb9848aa", new DateTime(2020, 12, 26, 19, 20, 12, 178, DateTimeKind.Local).AddTicks(7487), "PEPIBASKET@YAHOO.COM", "PEPIBASKET@YAHOO.COM", "AQAAAAEAACcQAAAAEDJvWt/bQr2Q6e9XMH4BmJBeKPeXvysLX5/ZWne3SQInnjDYXC4NhKJssZP+Zl3BTQ==", "854164d3-1274-4291-a33a-a74a2046866b" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d43e3dd4-4f55-4c84-92b2-94c4b84b924a",
                column: "CreatedOn",
                value: new DateTime(2020, 12, 27, 3, 20, 12, 188, DateTimeKind.Utc).AddTicks(4714));

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "AddedByUserId", "CreatedOn", "Extension", "ModifiedOn", "PropertyId", "RemoteImageUrl" },
                values: new object[] { "8eda1d0e-0496-41b2-83bf-c9e26049f569", "088bbcf3-2259-4570-93b8-cffbf7a064e5", new DateTime(2020, 12, 27, 3, 20, 12, 188, DateTimeKind.Utc).AddTicks(6471), "jpg", null, 2, null });

            migrationBuilder.InsertData(
                table: "MaintenanceServices",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "PropertyId", "ServiceDate", "VendorId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Bathroom repair", 1, new DateTime(2021, 11, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "CreatedOn", "DeletedOn", "IsDeleted", "ManagerId", "ModifiedOn", "Name", "Owner", "Size", "TenantId", "Type" },
                values: new object[,]
                {
                    { 3, "12252 Wood Canyon Dr., CA 92229", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Aliso Viejo House", "Home Properties LLC", 0, null, 0 },
                    { 4, "37 Baranca, Irvine, CA 92229", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Irvine Valley Home", "Home Properties LLC", 0, null, 0 },
                    { 5, "37 Newport Dr, Newport Beach, CA 92879", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Newport Mansion", "Home Properties LLC", 0, null, 0 },
                    { 6, "818 Johson Str, Long Beach, CA 81447", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Storage Place", "Rental Assets LLC", 0, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "AddedByUserId", "CreatedOn", "Extension", "ModifiedOn", "PropertyId", "RemoteImageUrl" },
                values: new object[,]
                {
                    { "1db364b0-cae7-4ba2-b5c9-19e88dc91347", "088bbcf3-2259-4570-93b8-cffbf7a064e5", new DateTime(2020, 12, 27, 3, 20, 12, 188, DateTimeKind.Utc).AddTicks(6650), "jpg", null, 3, null },
                    { "c04a661f-96be-4b9f-ab37-66a7b9e4bd2a", "088bbcf3-2259-4570-93b8-cffbf7a064e5", new DateTime(2020, 12, 27, 3, 20, 12, 188, DateTimeKind.Utc).AddTicks(6874), "jpg", null, 4, null },
                    { "31a41705-ec71-4839-8e83-a52d07574c5b", "088bbcf3-2259-4570-93b8-cffbf7a064e5", new DateTime(2020, 12, 27, 3, 20, 12, 188, DateTimeKind.Utc).AddTicks(7062), "jpg", null, 5, null },
                    { "9ff1e3ac-4af2-4fe6-9bdc-063121f86e82", "088bbcf3-2259-4570-93b8-cffbf7a064e5", new DateTime(2020, 12, 27, 3, 20, 12, 188, DateTimeKind.Utc).AddTicks(7229), "jpg", null, 6, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "1db364b0-cae7-4ba2-b5c9-19e88dc91347");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "31a41705-ec71-4839-8e83-a52d07574c5b");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "8eda1d0e-0496-41b2-83bf-c9e26049f569");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "9ff1e3ac-4af2-4fe6-9bdc-063121f86e82");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "c04a661f-96be-4b9f-ab37-66a7b9e4bd2a");

            migrationBuilder.DeleteData(
                table: "MaintenanceServices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "088bbcf3-2259-4570-93b8-cffbf7a064e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d67d5469-0a56-4c5b-a04d-9b231e85bb58", new DateTime(2020, 12, 26, 17, 57, 33, 725, DateTimeKind.Local).AddTicks(9127), null, null, "AQAAAAEAACcQAAAAEEhRjRjvl9QY0EZ63BcvUGi3L3iwuNniU1dDKocBrLnlaSeWBzsynQmtqDK6u/KeUQ==", "64ce6337-ba3b-4b4a-b768-b0eaec677421" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d43e3dd4-4f55-4c84-92b2-94c4b84b924a",
                column: "CreatedOn",
                value: new DateTime(2020, 12, 27, 1, 57, 33, 736, DateTimeKind.Utc).AddTicks(5094));
        }
    }
}
