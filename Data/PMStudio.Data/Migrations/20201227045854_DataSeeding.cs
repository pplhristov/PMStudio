using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMStudio.Data.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "Vendors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "B8A39BD0-1C75-4660-9749-0B47328E0720", "77bfd359-1824-4f8a-a9e1-1ac844cf0ccd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Administrator", "ADMINISTRATOR" },
                    { "5F2A7EDB-703F-479D-BFF9-F19164A66E3A", "1f67ee81-6d21-4bfb-b4d3-abc814ae2ba4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "088bbcf3-2259-4570-93b8-cffbf7a064e5", 0, "5692489b-71a5-4df7-ad0c-77e3b55b530f", new DateTime(2020, 12, 26, 20, 58, 53, 119, DateTimeKind.Local).AddTicks(8677), null, "pepibasket@yahoo.com", false, false, false, null, null, "PEPIBASKET@YAHOO.COM", "PEPIBASKET@YAHOO.COM", "AQAAAAEAACcQAAAAEHj8dN9Eb0p24FpGSZfdAtZzXG0VEzf4tgPpy9xYOGD5R/4qMCva5STZfArEw18K7A==", null, false, "7e305a2f-1985-4521-86d4-864eef913498", false, "pepibasket@yahoo.com" },
                    { "B20F8CEE-4341-46CC-84F7-FB75D269A2E4", 0, "527bdac9-ea12-45de-9a1c-b4afbd318943", new DateTime(2020, 12, 26, 20, 58, 53, 142, DateTimeKind.Local).AddTicks(4349), null, "vasa@gmail.com", false, false, false, null, null, "VASA@GMAIL.COM", "VASA@GMAIL.COM", "AQAAAAEAACcQAAAAEGjfOsjAaxduany0KE88wN4rU4abWkBf2IIlDgiOj/mbaF7vTTvdvckvf4anlROEYw==", null, false, "8b38c9e9-58cb-4143-9b69-906a28bfd791", false, "vasa@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "B8A39BD0-1C75-4660-9749-0B47328E0720", "088bbcf3-2259-4570-93b8-cffbf7a064e5" },
                    { "5F2A7EDB-703F-479D-BFF9-F19164A66E3A", "B20F8CEE-4341-46CC-84F7-FB75D269A2E4" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "CreatedOn", "DeletedOn", "IsDeleted", "ManagerId", "ModifiedOn", "Name", "Owner", "Size", "TenantId", "Type" },
                values: new object[,]
                {
                    { 2, "1822 Redhill, Irvine, Ca 92112", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Irvine Warehouse", "Logistics Solutions LLC", 0, null, 0 },
                    { 3, "12252 Wood Canyon Dr., CA 92229", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Aliso Viejo House", "Home Properties LLC", 0, null, 0 },
                    { 4, "37 Baranca, Irvine, CA 92229", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Irvine Valley Home", "Home Properties LLC", 0, null, 0 },
                    { 5, "37 Newport Dr, Newport Beach, CA 92879", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Newport Mansion", "Home Properties LLC", 0, null, 0 },
                    { 6, "818 Johson Str, Long Beach, CA 81447", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Storage Place", "Rental Assets LLC", 0, null, 0 },
                    { 1, "100 Marguerite Ave, Unit 2, Newport Beach, CA 92660", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Newport Condo", "WestCoast Investments", 0, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "LeasePeriod", "ManagerId", "ModifiedOn", "Name", "PropertyId", "Rate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 12, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "John Smith", 1, 3500 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 16, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Kristina Ivanova", 3, 1500 }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Address", "CreatedOn", "DeletedOn", "Email", "IsDeleted", "ManagerId", "ModifiedOn", "Name", "Phone", "Trade" },
                values: new object[,]
                {
                    { 10, "2151 Baranca, Santa Ana, CA 92650", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "info@securitycontrol.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Security Control LLC", "949-013-0103", "Alarm" },
                    { 9, "22th Ave, Los Angeles, CA 94422", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sara@modern.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Modern", "818-111-9951", "Interior Design" },
                    { 8, "22 6th Ave, Los Angeles, CA 94422", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "john@westex.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Westex", "818-521-4840", "HVAC" },
                    { 7, "110 Newport Dr, Newport Beach, CA 92418", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "help@pestexterminator.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "PestExterminators", "949-142-2284", "Pest Control" },
                    { 3, "1414 Von Karman Ave, Irvine, CA 92660", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "service@bestplumbing.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Best Plumbing Specialists", "714-111-4147", "Plumbing" },
                    { 5, "100 12th Str, Costa Mesa, CA 92414", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nick@fivestar.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Five Star Elevator", "914-747-1100", "Elevator Repairs" },
                    { 4, "218 Michelson Ave, Irvine, CA 92660", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "info@cleaningcrew.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Cleaning Crew", "714-111-5151", "Cleaning" },
                    { 11, "333 Marguerite, Long Beach, CA 92650", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "johnjohnson@gmail.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "John&John Co.", "714-214-3510", "Painting" },
                    { 12, "2020 Von Karman Ave, Irvine, CA 92660", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "help@cox.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Cox", "714-122-1338", "Telephones" },
                    { 6, "PO Box 104, Los Angeles, CA 95114", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "moving@movingforfun.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Moving For Fun", "949-555-5511", "Moving Services" },
                    { 13, "2020 Von Karman Ave, Irvine, CA 92660", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "help@at&t.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "AT&T", "714-511-5878", "Internet" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "AddedByUserId", "CreatedOn", "Extension", "ModifiedOn", "PropertyId", "RemoteImageUrl" },
                values: new object[,]
                {
                    { "d43e3dd4-4f55-4c84-92b2-94c4b84b924a", "088bbcf3-2259-4570-93b8-cffbf7a064e5", new DateTime(2020, 12, 27, 4, 58, 53, 145, DateTimeKind.Utc).AddTicks(3338), "jpg", null, 1, null },
                    { "8eda1d0e-0496-41b2-83bf-c9e26049f569", "088bbcf3-2259-4570-93b8-cffbf7a064e5", new DateTime(2020, 12, 27, 4, 58, 53, 145, DateTimeKind.Utc).AddTicks(5486), "jpg", null, 2, null },
                    { "1db364b0-cae7-4ba2-b5c9-19e88dc91347", "088bbcf3-2259-4570-93b8-cffbf7a064e5", new DateTime(2020, 12, 27, 4, 58, 53, 145, DateTimeKind.Utc).AddTicks(5690), "jpg", null, 3, null },
                    { "c04a661f-96be-4b9f-ab37-66a7b9e4bd2a", "088bbcf3-2259-4570-93b8-cffbf7a064e5", new DateTime(2020, 12, 27, 4, 58, 53, 145, DateTimeKind.Utc).AddTicks(5887), "jpg", null, 4, null },
                    { "31a41705-ec71-4839-8e83-a52d07574c5b", "088bbcf3-2259-4570-93b8-cffbf7a064e5", new DateTime(2020, 12, 27, 4, 58, 53, 145, DateTimeKind.Utc).AddTicks(6144), "jpg", null, 5, null },
                    { "9ff1e3ac-4af2-4fe6-9bdc-063121f86e82", "088bbcf3-2259-4570-93b8-cffbf7a064e5", new DateTime(2020, 12, 27, 4, 58, 53, 145, DateTimeKind.Utc).AddTicks(6331), "jpg", null, 6, null }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceServices",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "PropertyId", "ServiceDate", "VendorId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Bathroom repair", 1, new DateTime(2021, 11, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_ManagerId",
                table: "Vendors",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_AspNetUsers_ManagerId",
                table: "Vendors",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_AspNetUsers_ManagerId",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_ManagerId",
                table: "Vendors");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "B8A39BD0-1C75-4660-9749-0B47328E0720", "088bbcf3-2259-4570-93b8-cffbf7a064e5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5F2A7EDB-703F-479D-BFF9-F19164A66E3A", "B20F8CEE-4341-46CC-84F7-FB75D269A2E4" });

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
                table: "Images",
                keyColumn: "Id",
                keyValue: "d43e3dd4-4f55-4c84-92b2-94c4b84b924a");

            migrationBuilder.DeleteData(
                table: "MaintenanceServices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5F2A7EDB-703F-479D-BFF9-F19164A66E3A");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B8A39BD0-1C75-4660-9749-0B47328E0720");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B20F8CEE-4341-46CC-84F7-FB75D269A2E4");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "088bbcf3-2259-4570-93b8-cffbf7a064e5");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Vendors");
        }
    }
}
