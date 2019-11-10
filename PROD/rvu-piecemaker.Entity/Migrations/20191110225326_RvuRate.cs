using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RvuPiecemaker.Entity.Migrations
{
    public partial class RvuRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "RvuRate" },
                values: new object[] { "b39b7fd6-391c-4d74-ae0c-14a75b78866d", 38.0m });

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "RvuRate" },
                values: new object[] { "8162aab4-994a-4a36-b184-867c083484c3", 38.0m });

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 34,
                column: "RvuTotal",
                value: 0.18m);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 36,
                column: "ModalityId",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 43,
                column: "Name",
                value: "MRI Cervical Spine WO");

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 56,
                column: "RvuTotal",
                value: 0.68m);

            migrationBuilder.InsertData(
                schema: "Common",
                table: "ExamType",
                columns: new[] { "Id", "CptCode", "CreatedById", "CreatedDate", "Description", "IsAdmin", "LastModifiedById", "LastModifiedDate", "ModalityId", "Name", "RvuTotal" },
                values: new object[,]
                {
                    { 84, "71260+74177", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Chest/Abd/Pel W", 3.06m },
                    { 85, "71250+74146", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Chest/Abd/Pel WO", 2.9m },
                    { 86, "71270+74178", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Chest/Abd/Pel W/WO", 3.39m },
                    { 87, "70450+72125", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Brain/Cervical Spine", 1.92m },
                    { 88, "", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MR Enterography", 2.2m },
                    { 89, "76641", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Breast Complete", 0.73m },
                    { 90, "76642", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "76642 (1 modifier for BIL)", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Breast BIL LIM", 1.02m },
                    { 91, "76641", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Breast Complete", 0.73m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "RvuRate" },
                values: new object[] { "b39b7fd6-391c-4d74-ae0c-14a75b78866d", null });

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "RvuRate" },
                values: new object[] { "8162aab4-994a-4a36-b184-867c083484c3", null });

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 34,
                column: "RvuTotal",
                value: 10.18m);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 36,
                column: "ModalityId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 43,
                column: "Name",
                value: "RI Cervical Spine WO");

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 56,
                column: "RvuTotal",
                value: 0.74m);
        }
    }
}
