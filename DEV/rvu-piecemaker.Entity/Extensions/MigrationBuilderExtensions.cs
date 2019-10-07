using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace OASIS.Entity.Extensions
{
    public static class MigrationBuilderExtensions
    {
        public static MigrationBuilder EnableVersioning(this MigrationBuilder builder, string tableName, string schema)
        {
            builder.Sql($"ALTER TABLE {schema}.{tableName} " +
            "ADD StartTime DATETIME2 GENERATED ALWAYS AS ROW START " +
            "HIDDEN DEFAULT GETUTCDATE(), " +
            "EndTime  DATETIME2 GENERATED ALWAYS AS ROW END " +
            "HIDDEN DEFAULT " +
            "CONVERT(DATETIME2, '9999-12-31 23:59:59.9999999'), " +
            "PERIOD FOR SYSTEM_TIME(StartTime, EndTime)");

            builder.Sql($"ALTER TABLE[{schema}].[{tableName}] SET ( SYSTEM_VERSIONING = ON(HISTORY_TABLE = {schema}.{tableName}History))");
            return builder;
        }

        public static MigrationBuilder CreateGetStudentMatchUDF(this MigrationBuilder builder)
        {
            builder.Sql("CREATE FUNCTION[dbo].[GetStudentMatch] " +
            "(" +
            "@FirstName varchar(50), " +
            "@MiddleName varchar(50), " +
            "@LastName varchar(50), " +
            "@DateOfBirth date " +
            ") " +
            "RETURNS @returnTable TABLE(" +
            "    Id int, " +
            "    FirstName varchar(50), " +
            "    MiddleName varchar(50), " +
            "    LastName varchar(50), " +
            "    DateOfBirth datetime2, " +
            "    PaSecureId nvarchar(10), " +
            "    MatchScore int " +
            ") " +
            "AS " +
            "BEGIN " +
            "   INSERT INTO @returnTable " +
            "      SELECT[Id] " +
            "          ,[FirstName] " +
            "          ,[MiddleName] " +
            "          ,[LastName] " +
            "          ,[DOB] AS DateOfBirth " +
            "          ,[PaSecureId] " +
            "          , (DIFFERENCE(@LastName, [LastName]) * 5) " +
            "          + (DIFFERENCE(@FirstName, [FirstName]) * 5) " +
            "          + CASE WHEN 30 - ABS(DATEDIFF(day, @DateOfBirth, [DOB])) > 0 THEN 30 - ABS(DATEDIFF(day, @DateOfBirth, [DOB])) ELSE 0 END  AS MatchScore " +
            "     FROM[Students].[Student] " +
            "    ORDER BY MatchScore DESC " +
            "    RETURN " +
            "END");
            return builder;
        }

        public static MigrationBuilder CreateDefaultListValues(this MigrationBuilder migrationBuilder, string table, string schema)
        {
            migrationBuilder.Sql($"SET IDENTITY_INSERT [{schema}].[{table}] ON ");
            migrationBuilder.Sql($"INSERT INTO [{schema}].[{table}]([Id],[Name],[IsActive],[Sort])VALUES(0, '', 1, 0)");
            migrationBuilder.Sql($"SET IDENTITY_INSERT [{schema}].[{table}] OFF");

            return migrationBuilder;
        }
    }
}
