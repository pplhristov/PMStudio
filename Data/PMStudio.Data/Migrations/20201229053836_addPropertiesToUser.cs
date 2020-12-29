using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMStudio.Data.Migrations
{
    public partial class addPropertiesToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5F2A7EDB-703F-479D-BFF9-F19164A66E3A",
                column: "ConcurrencyStamp",
                value: "3876f0be-f400-4eb2-907e-2cb3b0bcd110");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B8A39BD0-1C75-4660-9749-0B47328E0720",
                column: "ConcurrencyStamp",
                value: "76e4a652-e0a5-4a17-b086-5462d124989c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "088bbcf3-2259-4570-93b8-cffbf7a064e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9725357d-b63f-4836-ac8d-94c0072e0140", new DateTime(2020, 12, 28, 21, 38, 34, 927, DateTimeKind.Local).AddTicks(6792), "AQAAAAEAACcQAAAAEIq2tWqej6WPFp4w1r6oPtzy7YwgtfT6srlGNXeROLOSznxvtl71Y5acva6bCy1SIw==", "11f0db43-955a-4444-bc1a-ca9517ec4a18" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B20F8CEE-4341-46CC-84F7-FB75D269A2E4",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c8a0a5e-b200-4bb7-8063-5c39b2509032", new DateTime(2020, 12, 28, 21, 38, 34, 941, DateTimeKind.Local).AddTicks(9484), "AQAAAAEAACcQAAAAEIdKDZYQcZBHCZQfgLiffKkmENad3Z0Oi9C2yrJt+gro6owf2Y/v5I5Zs1liH2rphQ==", "e1c5651f-1fcf-4639-ba2d-7660db883070" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "1db364b0-cae7-4ba2-b5c9-19e88dc91347",
                column: "CreatedOn",
                value: new DateTime(2020, 12, 29, 5, 38, 34, 943, DateTimeKind.Utc).AddTicks(8023));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "31a41705-ec71-4839-8e83-a52d07574c5b",
                column: "CreatedOn",
                value: new DateTime(2020, 12, 29, 5, 38, 34, 943, DateTimeKind.Utc).AddTicks(8190));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "8eda1d0e-0496-41b2-83bf-c9e26049f569",
                column: "CreatedOn",
                value: new DateTime(2020, 12, 29, 5, 38, 34, 943, DateTimeKind.Utc).AddTicks(7929));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "9ff1e3ac-4af2-4fe6-9bdc-063121f86e82",
                column: "CreatedOn",
                value: new DateTime(2020, 12, 29, 5, 38, 34, 943, DateTimeKind.Utc).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "c04a661f-96be-4b9f-ab37-66a7b9e4bd2a",
                column: "CreatedOn",
                value: new DateTime(2020, 12, 29, 5, 38, 34, 943, DateTimeKind.Utc).AddTicks(8103));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d43e3dd4-4f55-4c84-92b2-94c4b84b924a",
                column: "CreatedOn",
                value: new DateTime(2020, 12, 29, 5, 38, 34, 943, DateTimeKind.Utc).AddTicks(6685));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: 1);

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "CreatedOn", "DeletedOn", "IsDeleted", "ManagerId", "ModifiedOn", "Name", "Owner", "Size", "TenantId", "Type" },
                values: new object[,]
                {
                    { 7, "2 Avery, Boston, NA 40115", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "B20F8CEE-4341-46CC-84F7-FB75D269A2E4", null, "Grandview Boston", "Rental Assets LLC", 0, null, 0 },
                    { 8, "101 Cliff Dr, San Clemente, CA 90512", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "B20F8CEE-4341-46CC-84F7-FB75D269A2E4", null, "San Clemente Warehouse", "Logistic Solutics LLC", 0, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "AddedByUserId", "CreatedOn", "Extension", "ModifiedOn", "PropertyId", "RemoteImageUrl" },
                values: new object[] { "70383c88-03d2-477c-8f93-91611158f251", "088bbcf3-2259-4570-93b8-cffbf7a064e5", new DateTime(2020, 12, 29, 5, 38, 34, 943, DateTimeKind.Utc).AddTicks(8351), "jpg", null, 7, null });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "AddedByUserId", "CreatedOn", "Extension", "ModifiedOn", "PropertyId", "RemoteImageUrl" },
                values: new object[] { "21dad2a8-499b-479f-85a9-f0344eaa31dc", "088bbcf3-2259-4570-93b8-cffbf7a064e5", new DateTime(2020, 12, 29, 5, 38, 34, 943, DateTimeKind.Utc).AddTicks(8508), "jpg", null, 8, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "21dad2a8-499b-479f-85a9-f0344eaa31dc");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "70383c88-03d2-477c-8f93-91611158f251");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5F2A7EDB-703F-479D-BFF9-F19164A66E3A",
                column: "ConcurrencyStamp",
                value: "1f67ee81-6d21-4bfb-b4d3-abc814ae2ba4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B8A39BD0-1C75-4660-9749-0B47328E0720",
                column: "ConcurrencyStamp",
                value: "77bfd359-1824-4f8a-a9e1-1ac844cf0ccd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "088bbcf3-2259-4570-93b8-cffbf7a064e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5692489b-71a5-4df7-ad0c-77e3b55b530f", new DateTime(2020, 12, 26, 20, 58, 53, 119, DateTimeKind.Local).AddTicks(8677), "AQAAAAEAACcQAAAAEHj8dN9Eb0p24FpGSZfdAtZzXG0VEzf4tgPpy9xYOGD5R/4qMCva5STZfArEw18K7A==", "7e305a2f-1985-4521-86d4-864eef913498" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B20F8CEE-4341-46CC-84F7-FB75D269A2E4",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "527bdac9-ea12-45de-9a1c-b4afbd318943", new DateTime(2020, 12, 26, 20, 58, 53, 142, DateTimeKind.Local).AddTicks(4349), "AQAAAAEAACcQAAAAEGjfOsjAaxduany0KE88wN4rU4abWkBf2IIlDgiOj/mbaF7vTTvdvckvf4anlROEYw==", "8b38c9e9-58cb-4143-9b69-906a28bfd791" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "1db364b0-cae7-4ba2-b5c9-19e88dc91347",
                column: "CreatedOn",
                value: new DateTime(2020, 12, 27, 4, 58, 53, 145, DateTimeKind.Utc).AddTicks(5690));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "31a41705-ec71-4839-8e83-a52d07574c5b",
                column: "CreatedOn",
                value: new DateTime(2020, 12, 27, 4, 58, 53, 145, DateTimeKind.Utc).AddTicks(6144));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "8eda1d0e-0496-41b2-83bf-c9e26049f569",
                column: "CreatedOn",
                value: new DateTime(2020, 12, 27, 4, 58, 53, 145, DateTimeKind.Utc).AddTicks(5486));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "9ff1e3ac-4af2-4fe6-9bdc-063121f86e82",
                column: "CreatedOn",
                value: new DateTime(2020, 12, 27, 4, 58, 53, 145, DateTimeKind.Utc).AddTicks(6331));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "c04a661f-96be-4b9f-ab37-66a7b9e4bd2a",
                column: "CreatedOn",
                value: new DateTime(2020, 12, 27, 4, 58, 53, 145, DateTimeKind.Utc).AddTicks(5887));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d43e3dd4-4f55-4c84-92b2-94c4b84b924a",
                column: "CreatedOn",
                value: new DateTime(2020, 12, 27, 4, 58, 53, 145, DateTimeKind.Utc).AddTicks(3338));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: 0);
        }
    }
}
