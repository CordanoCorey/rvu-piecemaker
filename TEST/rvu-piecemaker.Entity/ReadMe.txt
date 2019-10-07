

Run this command:
dotnet tool install -g dotnet-aspnet-codegenerator
instead of adding this: <DotNetCliToolReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Tools" Version="2.0.4" />


Code migrations

Make sure you checkout the RvuPiecemakerContextModelSnapshot.cs file.  It may throw a read only error if you don't.
Make your changes to the entity class and context.
Run the command from the nuget package manager (make sure to change the dropdown to the entity project):

add-migration <name> -Context RvuPiecemakerContext

After the migration is created and the snapshot is updated run the command:

update-database

Note: The update-database command is not environment aware.  It uses the connection string in the appsetting.json file.  
I typically set it to "Server=oasisdevbackend;Database=oasisdev;User Id=Oasis;Password=Password#9".
This prevents issues when working remotely and trying to use integrated security.



Add to bottom of init migration Up method:
EnableAudit.Enable(migrationBuilder);
migrationBuilder.CreateGetStudentMatchUDF();
ListsSeed.SeedDefaultValues(migrationBuilder);

Entity Framework doesn't like to seed things in order.

migrationBuilder.InsertData(
                schema: "Services",
                table: "Services_tree",
                columns: new[] { "Id", "AbbreviatedName", "ActiveDate", "AdditionalNotes", "CreatedById", "CreatedDate", "HasFrequency", "InActiveDate", "IsActive", "IsProgram", "LastModifiedById", "LastModifiedDate", "MaintenancePercent", "Name", "ParentId", "SellableHours", "ServiceId", "SortOrder" },
                values: new object[,]
                {
                    { 1, "1:1", new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, null, null, null, "1:1 Class Placement", null, null, 12, 1 },
                    { 2, "AS", new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, null, null, null, "Autism Support Class Placement", null, null, 2, 2 },
                    { 3, "CAMhP", new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, null, null, null, "Capital Area Mental health Program (CAMhP)", null, null, 3, 3 },
                    { 4, "CATES", new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, null, null, null, "Capital Area Therapeutic Educational Services (CATES)", null, null, 4, 4 },
                    { 5, "DHIS", new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, null, null, null, "Deaf or Hard of Hearing Support Class Placement", null, null, 5, 5 },
                    { 6, "DC", new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, null, null, null, "Diagnostic Class", null, null, 6, 6 },
                    { 7, "CP", new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, null, null, null, "Diakon/Center Point Day Treatment Program", null, null, 7, 7 },
                    { 8, "ES", new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, null, null, null, "Emotional Support Class Placement", null, null, 8, 8 },
					{ 9, "MDS", new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, null, null, null, "Multiple Disabilities Support Class Placement", null, null, 9, 9 },
                    { 10, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Project SEARCH", null, null, 10, 10 },
                    { 11, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Assistive Technology", null, null, 11, 11 },
                    { 12, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Audiology", null, null, 12, 12 },
                    { 13, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Autism", null, null, 13, 13 },
                    { 14, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Blind or Visually Impaired", null, null, 14, 14 },
                    { 15, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Case Management", null, null, 15, 15 },
                    { 16, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Deaf or Hard Hearing", null, null, 16, 16 },
                    { 17, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Direct Educational Services", null, null, 17, 17 },
                    { 18, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Early Intervention", null, null, 18, 18 },
                    { 19, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Extended School Year", null, null, 19, 19 },
                    { 20, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Occupational Therapy", null, null, 20, 20 },
                    { 21, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Orientation & Mobility", null, null, 21, 21 },
                    { 22, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Personal Care Aide (PCA)", null, null, 22, 22 },
                    { 23, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Physical Therapy", null, null, 23, 23 },
                    { 24, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Positive Behavior Support", null, null, 24, 24 },
                    { 25, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Psychiatric Evaluation", null, null, 25, 25 },
                    { 26, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Psychological", null, null, 26, 26 },
                    { 27, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Psychological Counseling", null, null, 27, 27 },
                    { 28, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "School Health Services", null, null, 28, 28 },
                    { 29, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Social Work", null, null, 29, 29 },
                    { 30, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Speech & Language", null, null, 30, 30 },
                    { 31, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Transition Support", null, null, 31, 31 },
                    { 32, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Adaptive Physical Education", null, null, 32, 32 },
                    { 33, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Audiometer Calibration", null, null, 33, 33 },
                    { 34, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Experiential Education and Learnining", null, null, 34, 34 },
                    { 35, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Mental Health Worker", null, null, 35, 35 },
                    { 36, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Safe Crisis Management (SCM) Training - Certification", null, null, 36, 36 },
                    { 37, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Safe Crisis Management (SCM) Training - Recertification", null, null, 37, 37 },
                    { 38, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "SBAP Consultation or Billing", null, null, 38, 38 },
                    { 39, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Sign Language Interrupter", null, null, 39, 39 },
                    { 40, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Special Education Coaching", null, null, 40, 40 },
                    { 41, null, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null, "Work Based Learning Experience - Para", null, null, 41, 41 }
                });


				After syncing the EDNA locations you will need to set the default state to PA
				migrationBuilder.Sql("UPDATE [Common].[Location] SET [StateId] = 39");