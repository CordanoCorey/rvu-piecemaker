using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RvuPiecemaker.Entity.Migrations
{
    public partial class add_exam_types_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 70,
                column: "Name",
                value: "MRI Neck/Face W/WO");

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 80,
                column: "Name",
                value: "CT Maxillofacial W/WO");

            migrationBuilder.InsertData(
                schema: "Common",
                table: "ExamType",
                columns: new[] { "Id", "CptCode", "CreatedById", "CreatedDate", "Description", "IsAdmin", "LastModifiedById", "LastModifiedDate", "ModalityId", "Name", "RvuTotal" },
                values: new object[,]
                {
                    { 104, "", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "MG Stereotactic Biopsy 2D", 0.0m },
                    { 103, "", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "MG Stereotactic Biopsy 3D", 0.0m },
                    { 102, "", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Breast Biopsy", 0.0m },
                    { 101, "", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Breast", 0.0m },
                    { 100, "", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Breast Biopsy WO vacuum", 0.0m },
                    { 99, "19083", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Breast Biopsy vacuum", 3.1m },
                    { 98, "93880", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Carotid", 0.8m },
                    { 97, "76882", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US soft tissue limited", 0.49m },
                    { 96, "76817", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Pregnant Uterus TV", 0.75m },
                    { 95, "76536", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Head/Neck", 0.56m },
                    { 94, "76506", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Head", 0.63m },
                    { 93, "71550", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Chest WO", 1.46m },
                    { 92, "70492", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Neck W/WO", 1.62m },
                    { 105, "73218", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Upper Extremity WO", 1.35m },
                    { 106, "73220", 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "MRI Upper Extremity W/WO", 2.15m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 70,
                column: "Name",
                value: "MRI Face W/WO");

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ExamType",
                keyColumn: "Id",
                keyValue: 80,
                column: "Name",
                value: "CT Face W/WO");
        }
    }
}
