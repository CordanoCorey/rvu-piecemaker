using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RvuPiecemaker.Entity.Migrations
{
    public partial class add_exam_types : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CptCode", "RvuTotal" },
                values: new object[] { "76642", 0.74m });

            migrationBuilder.InsertData(
                schema: "Common",
                table: "ExamType",
                columns: new[] { "Id", "CptCode", "CreatedById", "CreatedDate", "Description", "IsAdmin", "LastModifiedById", "LastModifiedDate", "ModalityId", "Name", "RvuTotal" },
                values: new object[,]
                {
                    { 70, "70543", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Face W/WO", 2.15m },
                    { 71, "72133", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Lumbar spine W/WO", 1.27m },
                    { 72, "76377", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "3D Rendering add-on", 0.76m },
                    { 73, "77063+77067", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Screening Breast Tomo", 1.36m },
                    { 74, "77067", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Screening Mammogram 2D", 0.76m },
                    { 75, "G0279+77065", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Dx Breast Tomo UNI", 1.41m },
                    { 76, "G0279+77066", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Dx Breast Tomo BIL", 1.6m },
                    { 77, "77066", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Dx 2D Mammogram BIL", 1.0m },
                    { 78, "77065", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Dx 2D Mammogram UNI", 0.81m },
                    { 79, "75635", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CTA AortoBifem W/WO", 2.4m },
                    { 80, "70488", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Face W/WO", 1.27m },
                    { 81, "76830", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Pelvis TV", 0.69m },
                    { 82, "76700", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Abdomen Complete", 0.81m },
                    { 83, "76856", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Pelvis TA", 0.69m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CptCode", "RvuTotal" },
                values: new object[] { "6642", 0.68m });
        }
    }
}
