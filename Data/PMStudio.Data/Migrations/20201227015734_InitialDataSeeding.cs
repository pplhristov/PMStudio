﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMStudio.Data.Migrations
{
    public partial class InitialDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "Vendors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "088bbcf3-2259-4570-93b8-cffbf7a064e5", 0, "d67d5469-0a56-4c5b-a04d-9b231e85bb58", new DateTime(2020, 12, 26, 17, 57, 33, 725, DateTimeKind.Local).AddTicks(9127), null, "pepibasket@yahoo.com", false, false, false, null, null, null, null, "AQAAAAEAACcQAAAAEEhRjRjvl9QY0EZ63BcvUGi3L3iwuNniU1dDKocBrLnlaSeWBzsynQmtqDK6u/KeUQ==", null, false, "64ce6337-ba3b-4b4a-b768-b0eaec677421", false, "pepibasket@yahoo.com" });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "CreatedOn", "DeletedOn", "IsDeleted", "ManagerId", "ModifiedOn", "Name", "Owner", "Size", "TenantId", "Type" },
                values: new object[,]
                {
                    { 1, "100 Marguerite Ave, Unit 2, Newport Beach, CA 92660", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Newport Condo", "WestCoast Investments", 0, null, 0 },
                    { 2, "1822 Redhill, Irvine, Ca 92112", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Irvine Warehouse", "Logistics Solutions LLC", 0, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Address", "CreatedOn", "DeletedOn", "Email", "IsDeleted", "ManagerId", "ModifiedOn", "Name", "Phone", "Trade" },
                values: new object[,]
                {
                    { 12, "2020 Von Karman Ave, Irvine, CA 92660", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "help@cox.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Cox", "714-122-1338", "Telephones" },
                    { 13, "2020 Von Karman Ave, Irvine, CA 92660", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "help@at&t.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "AT&T", "714-511-5878", "Internet" },
                    { 3, "1414 Von Karman Ave, Irvine, CA 92660", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "service@bestplumbing.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Best Plumbing Specialists", "714-111-4147", "Plumbing" },
                    { 4, "218 Michelson Ave, Irvine, CA 92660", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "info@cleaningcrew.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Cleaning Crew", "714-111-5151", "Cleaning" },
                    { 5, "100 12th Str, Costa Mesa, CA 92414", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nick@fivestar.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Five Star Elevator", "914-747-1100", "Elevator Repairs" },
                    { 6, "PO Box 104, Los Angeles, CA 95114", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "moving@movingforfun.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Moving For Fun", "949-555-5511", "Moving Services" },
                    { 7, "110 Newport Dr, Newport Beach, CA 92418", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "help@pestexterminator.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "PestExterminators", "949-142-2284", "Pest Control" },
                    { 8, "22 6th Ave, Los Angeles, CA 94422", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "john@westex.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Westex", "818-521-4840", "HVAC" },
                    { 9, "22th Ave, Los Angeles, CA 94422", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sara@modern.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Modern", "818-111-9951", "Interior Design" },
                    { 10, "2151 Baranca, Santa Ana, CA 92650", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "info@securitycontrol.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "Security Control LLC", "949-013-0103", "Alarm" },
                    { 11, "333 Marguerite, Long Beach, CA 92650", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "johnjohnson@gmail.com", false, "088bbcf3-2259-4570-93b8-cffbf7a064e5", null, "John&John Co.", "714-214-3510", "Painting" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "AddedByUserId", "CreatedOn", "Extension", "ModifiedOn", "PropertyId", "RemoteImageUrl" },
                values: new object[] { "d43e3dd4-4f55-4c84-92b2-94c4b84b924a", "088bbcf3-2259-4570-93b8-cffbf7a064e5", new DateTime(2020, 12, 27, 1, 57, 33, 736, DateTimeKind.Utc).AddTicks(5094), "jpg", null, 1, null });

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
                table: "Images",
                keyColumn: "Id",
                keyValue: "d43e3dd4-4f55-4c84-92b2-94c4b84b924a");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 3);

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
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

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