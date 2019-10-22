using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RvuPiecemaker.Entity.Migrations
{
  public partial class init : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      Pre(migrationBuilder);
      migrationBuilder.EnsureSchema(
          name: "Auth");

      migrationBuilder.EnsureSchema(
          name: "Common");

      migrationBuilder.EnsureSchema(
          name: "Lookup");

      migrationBuilder.CreateTable(
          name: "Role",
          schema: "Auth",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            Name = table.Column<string>(maxLength: 256, nullable: true),
            NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
            ConcurrencyStamp = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Role", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "ShiftType",
          schema: "Common",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            Name = table.Column<string>(maxLength: 100, nullable: true),
            Description = table.Column<string>(maxLength: 200, nullable: true),
            StartHour = table.Column<int>(nullable: false),
            StartMinute = table.Column<int>(nullable: false),
            EndHour = table.Column<int>(nullable: false),
            EndMinute = table.Column<int>(nullable: false),
            IsAdmin = table.Column<bool>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ShiftType", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "CalendarEventType",
          schema: "Lookup",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            Name = table.Column<string>(maxLength: 100, nullable: false),
            IsActive = table.Column<bool>(nullable: false),
            Sort = table.Column<int>(nullable: false),
            AllDayEvent = table.Column<bool>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_CalendarEventType", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "DoctorType",
          schema: "Lookup",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            Name = table.Column<string>(maxLength: 100, nullable: false),
            IsActive = table.Column<bool>(nullable: false),
            Sort = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_DoctorType", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Modality",
          schema: "Lookup",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            Name = table.Column<string>(maxLength: 100, nullable: false),
            IsActive = table.Column<bool>(nullable: false),
            Sort = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Modality", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "YearType",
          schema: "Lookup",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            Name = table.Column<string>(maxLength: 100, nullable: false),
            IsActive = table.Column<bool>(nullable: false),
            Sort = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_YearType", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "RoleClaim",
          schema: "Auth",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            RoleId = table.Column<int>(nullable: false),
            ClaimType = table.Column<string>(nullable: true),
            ClaimValue = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_RoleClaim", x => x.Id);
            table.ForeignKey(
                      name: "FK_RoleClaim_Role_RoleId",
                      column: x => x.RoleId,
                      principalSchema: "Auth",
                      principalTable: "Role",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "User",
          schema: "Auth",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            UserName = table.Column<string>(maxLength: 256, nullable: true),
            NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
            Email = table.Column<string>(maxLength: 256, nullable: true),
            NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
            EmailConfirmed = table.Column<bool>(nullable: false),
            PasswordHash = table.Column<string>(nullable: true),
            SecurityStamp = table.Column<string>(nullable: true),
            ConcurrencyStamp = table.Column<string>(nullable: true),
            PhoneNumber = table.Column<string>(nullable: true),
            PhoneNumberConfirmed = table.Column<bool>(nullable: false),
            TwoFactorEnabled = table.Column<bool>(nullable: false),
            LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
            LockoutEnabled = table.Column<bool>(nullable: false),
            AccessFailedCount = table.Column<int>(nullable: false),
            DoctorTypeId = table.Column<int>(nullable: true),
            FirstName = table.Column<string>(nullable: true),
            LastName = table.Column<string>(nullable: true),
            PasswordResetCode = table.Column<string>(nullable: true),
            RvuRate = table.Column<decimal>(nullable: true),
            ShiftTypeId = table.Column<int>(nullable: true),
            YearTypeId = table.Column<int>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_User", x => x.Id);
            table.ForeignKey(
                      name: "FK_ApplicationUser_DoctorType",
                      column: x => x.DoctorTypeId,
                      principalSchema: "Lookup",
                      principalTable: "DoctorType",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_ApplicationUser_ShiftType",
                      column: x => x.ShiftTypeId,
                      principalSchema: "Common",
                      principalTable: "ShiftType",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_ApplicationUser_YearType",
                      column: x => x.YearTypeId,
                      principalSchema: "Lookup",
                      principalTable: "YearType",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Year",
          schema: "Lookup",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            Name = table.Column<string>(maxLength: 100, nullable: false),
            IsActive = table.Column<bool>(nullable: false),
            Sort = table.Column<int>(nullable: false),
            YearTypeId = table.Column<int>(nullable: false),
            StartDate = table.Column<DateTime>(nullable: false),
            EndDate = table.Column<DateTime>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Year", x => x.Id);
            table.ForeignKey(
                      name: "FK_Year_YearType",
                      column: x => x.YearTypeId,
                      principalSchema: "Lookup",
                      principalTable: "YearType",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "UserClaim",
          schema: "Auth",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            UserId = table.Column<int>(nullable: false),
            ClaimType = table.Column<string>(nullable: true),
            ClaimValue = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_UserClaim", x => x.Id);
            table.ForeignKey(
                      name: "FK_UserClaim_User_UserId",
                      column: x => x.UserId,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "UserLogin",
          schema: "Auth",
          columns: table => new
          {
            LoginProvider = table.Column<string>(nullable: false),
            ProviderKey = table.Column<string>(nullable: false),
            ProviderDisplayName = table.Column<string>(nullable: true),
            UserId = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_UserLogin", x => new { x.ProviderKey, x.LoginProvider });
            table.UniqueConstraint("AK_UserLogin_LoginProvider_ProviderKey", x => new { x.LoginProvider, x.ProviderKey });
            table.ForeignKey(
                      name: "FK_UserLogin_User_UserId",
                      column: x => x.UserId,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "UserRole",
          schema: "Auth",
          columns: table => new
          {
            UserId = table.Column<int>(nullable: false),
            RoleId = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_UserRole", x => new { x.RoleId, x.UserId });
            table.UniqueConstraint("AK_UserRole_UserId_RoleId", x => new { x.UserId, x.RoleId });
            table.ForeignKey(
                      name: "FK_UserRole_Role_RoleId",
                      column: x => x.RoleId,
                      principalSchema: "Auth",
                      principalTable: "Role",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_UserRole_User_UserId",
                      column: x => x.UserId,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "UserToken",
          schema: "Auth",
          columns: table => new
          {
            UserId = table.Column<int>(nullable: false),
            LoginProvider = table.Column<string>(nullable: false),
            Name = table.Column<string>(nullable: false),
            Value = table.Column<string>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.Value, x.LoginProvider });
            table.UniqueConstraint("AK_UserToken_UserId_LoginProvider_Name", x => new { x.UserId, x.LoginProvider, x.Name });
            table.ForeignKey(
                      name: "FK_UserToken_User_UserId",
                      column: x => x.UserId,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "ExamGroup",
          schema: "Common",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            Name = table.Column<string>(maxLength: 100, nullable: true),
            Description = table.Column<string>(maxLength: 200, nullable: true),
            CreatedById = table.Column<int>(nullable: false),
            CreatedDate = table.Column<DateTime>(nullable: false),
            LastModifiedById = table.Column<int>(nullable: false),
            LastModifiedDate = table.Column<DateTime>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ExamGroup", x => x.Id);
            table.ForeignKey(
                      name: "FK_ExamGroup_CreatedByUser",
                      column: x => x.CreatedById,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_ExamGroup_LastModifiedByUser",
                      column: x => x.LastModifiedById,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "ExamType",
          schema: "Common",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            Name = table.Column<string>(maxLength: 100, nullable: true),
            Description = table.Column<string>(maxLength: 200, nullable: true),
            RvuTotal = table.Column<decimal>(nullable: false),
            CptCode = table.Column<string>(maxLength: 20, nullable: true),
            ModalityId = table.Column<int>(nullable: false),
            IsAdmin = table.Column<bool>(nullable: false),
            CreatedById = table.Column<int>(nullable: false),
            CreatedDate = table.Column<DateTime>(nullable: false),
            LastModifiedById = table.Column<int>(nullable: false),
            LastModifiedDate = table.Column<DateTime>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ExamType", x => x.Id);
            table.ForeignKey(
                      name: "FK_ExamType_CreatedByUser",
                      column: x => x.CreatedById,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_ExamType_LastModifiedByUser",
                      column: x => x.LastModifiedById,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_ExamType_Modality",
                      column: x => x.ModalityId,
                      principalSchema: "Lookup",
                      principalTable: "Modality",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "Service",
          schema: "Common",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            Name = table.Column<string>(maxLength: 100, nullable: true),
            Description = table.Column<string>(maxLength: 200, nullable: true),
            DoctorTypeId = table.Column<int>(nullable: false),
            ParentId = table.Column<int>(nullable: true),
            CreatedById = table.Column<int>(nullable: false),
            CreatedDate = table.Column<DateTime>(nullable: false),
            LastModifiedById = table.Column<int>(nullable: false),
            LastModifiedDate = table.Column<DateTime>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Service", x => x.Id);
            table.ForeignKey(
                      name: "FK_Service_CreatedByUser",
                      column: x => x.CreatedById,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_Service_DoctorType",
                      column: x => x.DoctorTypeId,
                      principalSchema: "Lookup",
                      principalTable: "DoctorType",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_Service_LastModifiedByUser",
                      column: x => x.LastModifiedById,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_Service_Service_ParentId",
                      column: x => x.ParentId,
                      principalSchema: "Common",
                      principalTable: "Service",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Shift",
          schema: "Common",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            UserId = table.Column<int>(nullable: false),
            ShiftTypeId = table.Column<int>(nullable: false),
            StartTime = table.Column<DateTime>(nullable: true),
            EndTime = table.Column<DateTime>(nullable: true),
            RvuRate = table.Column<decimal>(nullable: true),
            RvuTotal = table.Column<decimal>(nullable: true),
            CreatedById = table.Column<int>(nullable: false),
            CreatedDate = table.Column<DateTime>(nullable: false),
            LastModifiedById = table.Column<int>(nullable: false),
            LastModifiedDate = table.Column<DateTime>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Shift", x => x.Id);
            table.ForeignKey(
                      name: "FK_Shift_CreatedByUser",
                      column: x => x.CreatedById,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_Shift_LastModifiedByUser",
                      column: x => x.LastModifiedById,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_Shift_ShiftType",
                      column: x => x.ShiftTypeId,
                      principalSchema: "Common",
                      principalTable: "ShiftType",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_Shift_User",
                      column: x => x.UserId,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "UserShiftType_xref",
          schema: "Common",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            ShiftTypeId = table.Column<int>(nullable: false),
            UserId = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_UserShiftType_xref", x => x.Id);
            table.ForeignKey(
                      name: "FK_UserShiftType_xref_ShiftType",
                      column: x => x.ShiftTypeId,
                      principalSchema: "Common",
                      principalTable: "ShiftType",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_UserShiftType_xref_ApplicationUser",
                      column: x => x.UserId,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "Calendar",
          schema: "Common",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            Name = table.Column<string>(maxLength: 100, nullable: true),
            StartDate = table.Column<DateTime>(nullable: true),
            EndDate = table.Column<DateTime>(nullable: true),
            IsMaster = table.Column<bool>(nullable: false, defaultValue: false),
            Description = table.Column<string>(maxLength: 100, nullable: true),
            YearId = table.Column<int>(nullable: true),
            ParentId = table.Column<int>(nullable: true),
            Notes = table.Column<string>(maxLength: 250, nullable: true),
            CreatedById = table.Column<int>(nullable: false),
            CreatedDate = table.Column<DateTime>(nullable: false),
            LastModifiedById = table.Column<int>(nullable: false),
            LastModifiedDate = table.Column<DateTime>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Calendar", x => x.Id);
            table.ForeignKey(
                      name: "FK_Calendar_CreatedByUser",
                      column: x => x.CreatedById,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_Calendar_LastModifiedByUser",
                      column: x => x.LastModifiedById,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_Calendar_Calendar_ParentId",
                      column: x => x.ParentId,
                      principalSchema: "Common",
                      principalTable: "Calendar",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_Calendar_Year_YearId",
                      column: x => x.YearId,
                      principalSchema: "Lookup",
                      principalTable: "Year",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Goal",
          schema: "Common",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            UserId = table.Column<int>(nullable: false),
            YearId = table.Column<int>(nullable: false),
            DollarAmount = table.Column<decimal>(nullable: false),
            CreatedById = table.Column<int>(nullable: false),
            CreatedDate = table.Column<DateTime>(nullable: false),
            LastModifiedById = table.Column<int>(nullable: false),
            LastModifiedDate = table.Column<DateTime>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Goal", x => x.Id);
            table.ForeignKey(
                      name: "FK_Goal_CreatedByUser",
                      column: x => x.CreatedById,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_Goal_LastModifiedByUser",
                      column: x => x.LastModifiedById,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_Goal_User",
                      column: x => x.UserId,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_Goal_Year_YearId",
                      column: x => x.YearId,
                      principalSchema: "Lookup",
                      principalTable: "Year",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "ExamGroup_xref",
          schema: "Common",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            ExamTypeId = table.Column<int>(nullable: false),
            ExamGroupId = table.Column<int>(nullable: false),
            Order = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ExamGroup_xref", x => x.Id);
            table.ForeignKey(
                      name: "FK_ExamGroup_xref_ExamGroup",
                      column: x => x.ExamGroupId,
                      principalSchema: "Common",
                      principalTable: "ExamGroup",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_ExamGroup_xref_ExamType",
                      column: x => x.ExamTypeId,
                      principalSchema: "Common",
                      principalTable: "ExamType",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "ServiceExamType_xref",
          schema: "Common",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            ExamTypeId = table.Column<int>(nullable: false),
            ServiceId = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ServiceExamType_xref", x => x.Id);
            table.ForeignKey(
                      name: "FK_ServiceExamType_xref_ExamType",
                      column: x => x.ExamTypeId,
                      principalSchema: "Common",
                      principalTable: "ExamType",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_ServiceExamType_xref_Service",
                      column: x => x.ServiceId,
                      principalSchema: "Common",
                      principalTable: "Service",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "Exam",
          schema: "Common",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            ExamTypeId = table.Column<int>(nullable: false),
            ServiceId = table.Column<int>(nullable: false),
            ShiftId = table.Column<int>(nullable: true),
            UserId = table.Column<int>(nullable: true),
            Notes = table.Column<string>(maxLength: 200, nullable: true),
            RvuTotal = table.Column<decimal>(nullable: true),
            StartTime = table.Column<DateTime>(nullable: false),
            EndTime = table.Column<DateTime>(nullable: true),
            CreatedById = table.Column<int>(nullable: false),
            CreatedDate = table.Column<DateTime>(nullable: false),
            LastModifiedById = table.Column<int>(nullable: false),
            LastModifiedDate = table.Column<DateTime>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Exam", x => x.Id);
            table.ForeignKey(
                      name: "FK_Exam_CreatedByUser",
                      column: x => x.CreatedById,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_Exam_ExamType",
                      column: x => x.ExamTypeId,
                      principalSchema: "Common",
                      principalTable: "ExamType",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_Exam_LastModifiedByUser",
                      column: x => x.LastModifiedById,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_Exam_Service",
                      column: x => x.ServiceId,
                      principalSchema: "Common",
                      principalTable: "Service",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_Exam_Shift",
                      column: x => x.ShiftId,
                      principalSchema: "Common",
                      principalTable: "Shift",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_Exam_User",
                      column: x => x.UserId,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "ShiftService_xref",
          schema: "Common",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            ServiceId = table.Column<int>(nullable: false),
            ShiftId = table.Column<int>(nullable: false),
            DurationMinutes = table.Column<int>(nullable: true),
            StartTime = table.Column<DateTime>(nullable: true),
            EndTime = table.Column<DateTime>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ShiftService_xref", x => x.Id);
            table.ForeignKey(
                      name: "FK_ShiftService_xref_Service",
                      column: x => x.ServiceId,
                      principalSchema: "Common",
                      principalTable: "Service",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_ShiftService_xref_Shift",
                      column: x => x.ShiftId,
                      principalSchema: "Common",
                      principalTable: "Shift",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "CalendarEvent",
          schema: "Common",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            CalendarId = table.Column<int>(nullable: true),
            CalendarEventTypeId = table.Column<int>(nullable: false),
            StartDate = table.Column<DateTime>(nullable: false),
            EndDate = table.Column<DateTime>(nullable: false),
            Description = table.Column<string>(maxLength: 100, nullable: true),
            CreatedById = table.Column<int>(nullable: false),
            CreatedDate = table.Column<DateTime>(nullable: false),
            LastModifiedById = table.Column<int>(nullable: false),
            LastModifiedDate = table.Column<DateTime>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_CalendarEvent", x => x.Id);
            table.ForeignKey(
                      name: "FK_CalendarEvent_CalendarEventType",
                      column: x => x.CalendarEventTypeId,
                      principalSchema: "Lookup",
                      principalTable: "CalendarEventType",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_CalendarEvent_Calendar",
                      column: x => x.CalendarId,
                      principalSchema: "Common",
                      principalTable: "Calendar",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_CalendarEvent_CreatedByUser",
                      column: x => x.CreatedById,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_CalendarEvent_LastModifiedByUser",
                      column: x => x.LastModifiedById,
                      principalSchema: "Auth",
                      principalTable: "User",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.InsertData(
          schema: "Common",
          table: "ShiftType",
          columns: new[] { "Id", "Description", "EndHour", "EndMinute", "IsAdmin", "Name", "StartHour", "StartMinute" },
          values: new object[,]
          {
                    { 1, "Default Radiology Hours", 16, 45, true, "Default Day", 7, 30 },
                    { 2, "", 21, 0, true, "1-9PM", 13, 0 },
                    { 3, "", 23, 0, true, "3-11PM", 15, 0 }
          });

      migrationBuilder.InsertData(
          schema: "Lookup",
          table: "DoctorType",
          columns: new[] { "Id", "IsActive", "Name", "Sort" },
          values: new object[] { 1, true, "Radiologist", 1 });

      migrationBuilder.InsertData(
          schema: "Lookup",
          table: "Modality",
          columns: new[] { "Id", "IsActive", "Name", "Sort" },
          values: new object[,]
          {
                    { 1, true, "CR", 1 },
                    { 2, true, "CT", 2 },
                    { 3, true, "MG", 3 },
                    { 4, true, "MR", 4 },
                    { 5, true, "NM", 5 },
                    { 6, true, "US", 6 },
                    { 7, true, "OT", 7 },
                    { 8, true, "PT", 8 }
          });

      migrationBuilder.InsertData(
          schema: "Lookup",
          table: "YearType",
          columns: new[] { "Id", "IsActive", "Name", "Sort" },
          values: new object[,]
          {
                    { 1, true, "Calendar Year", 1 },
                    { 2, true, "Fiscal Year", 2 },
                    { 3, true, "School Year", 3 }
          });

      migrationBuilder.InsertData(
          schema: "Auth",
          table: "User",
          columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DoctorTypeId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordResetCode", "PhoneNumber", "PhoneNumberConfirmed", "RvuRate", "SecurityStamp", "ShiftTypeId", "TwoFactorEnabled", "UserName", "YearTypeId" },
          values: new object[,]
          {
                    { 1, 0, "f605120f-716d-40c3-9dbd-8ff473410823", null, "gelbaughcm@gmail.com", false, "System", "Administrator", false, null, "GELBAUGHCM@GMAIL.COM", "GELBAUGHCM@GMAIL.COM", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, 33.3m, "dfafd561-8cef-40ad-8c7a-339dc67529d0", 1, false, "gelbaughcm@gmail.com", 1 },
                    { 2, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", 1, "dmartingrad@gmail.com", false, "Doug", "Martin", false, null, "DMARTINGRAD@GMAIL.COM", "DMARTINGRAD@GMAIL.COM", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, null, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", 1, false, "dmartingrad@gmail.com", 1 },
                    { 3, 0, "8162aab4-994a-4a36-b184-867c083484c3", 1, "pspotok@verizon.net", false, "Paul", "Potok", false, null, "PSPOTOK@VERIZON.NET", "PSPOTOK@VERIZON.NET", "AAQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, null, "MKZ5DGRD44RCRJFUGZTIYTWZJ2IXSHUE", 1, false, "pspotok@verizon.net", 1 }
          });

      migrationBuilder.InsertData(
          schema: "Lookup",
          table: "Year",
          columns: new[] { "Id", "EndDate", "IsActive", "Name", "Sort", "StartDate", "YearTypeId" },
          values: new object[,]
          {
                    { 1, new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "2019", 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "2020", 2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
          });

      migrationBuilder.InsertData(
          schema: "Common",
          table: "ExamType",
          columns: new[] { "Id", "CptCode", "CreatedById", "CreatedDate", "Description", "IsAdmin", "LastModifiedById", "LastModifiedDate", "ModalityId", "Name", "RvuTotal" },
          values: new object[,]
          {
                    { 1, "71250", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Chest W/O", 1.16m },
                    { 38, "70549", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRA Neck W/WO", 1.80m },
                    { 39, "70551", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Brain WO", 1.48m },
                    { 40, "70553", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Brain W/WO", 2.29m },
                    { 41, "70552", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Brain W", 1.78m },
                    { 42, "71552", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Chest W/WO", 2.26m },
                    { 43, "72141", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "RI Cervical Spine WO", 1.48m },
                    { 44, "72146", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Thoracic Spine WO", 1.48m },
                    { 45, "72148", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Lumbar Spine WO", 1.48m },
                    { 46, "72156", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Cervical Spine W/WO", 2.29m },
                    { 47, "72157", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Thoracic Spine W/WO", 2.29m },
                    { 48, "72158", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Lumbar Spine W/WO", 2.29m },
                    { 49, "72195", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Pelvis WO", 1.46m },
                    { 50, "72197", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Pelvis W/WO", 2.20m },
                    { 51, "74181", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Abdomen WO", 1.46m },
                    { 53, "73718", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Lower Extremity WO", 1.35m },
                    { 54, "73720", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Lower Extremity W/WO", 2.15m },
                    { 55, "73721", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Lower Extremity Joint WO", 1.35m },
                    { 69, "77067", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Screening Mammogram 2D CAD", 0.76m },
                    { 68, "70490", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Neck WO", 1.28m },
                    { 67, "76801", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US OB <14 Weeks, Single Fetus", 0.99m },
                    { 66, "G0297", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Chest Low Dose Screen", 1.02m },
                    { 65, "793975", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Duplex Abd/Pel Complete", 1.16m },
                    { 64, "93971", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Extremity Venous Unilateral", 0.45m },
                    { 37, "70547", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRA Neck WO", 1.20m },
                    { 63, "93970", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Extremity Venous Bilateral", 0.70m },
                    { 61, "76870", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Scrotum", 0.64m },
                    { 60, "76706", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Aorta Screen Limited", 0.55m },
                    { 59, "76775", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Retroperitoneal Limited", 0.58m },
                    { 58, "776770", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Retroperitoneal Complete", 0.74m },
                    { 57, "76705", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Abdomen Limited", 0.59m },
                    { 56, "6642", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Breast UNI Limited", 0.68m },
                    { 62, "76857", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "US Pelvis Limited", 0.5m },
                    { 36, "70544", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "MRA Head WO", 1.2m },
                    { 52, "74183", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Abdomen W/WO", 2.20m },
                    { 34, "71046", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CR", 10.18m },
                    { 15, "72128", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Thoracic Spine WO", 1.0m },
                    { 14, "72125", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Cervical Spine W", 1.22m },
                    { 13, "72125", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Cervical Spine WO", 1.07m },
                    { 12, "71275", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CTA Chest W/WO", 1.82m },
                    { 11, "71270", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Chest W/WO", 1.38m },
                    { 10, "70498", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CTA Neck W/WO", 1.75m },
                    { 16, "72129", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Thoracic Spine W", 1.22m },
                    { 9, "70496", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CTA Head W/WO", 1.75m },
                    { 7, "70487", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Maxillofacial W", 1.13m },
                    { 6, "70486", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Maxillofacial WO", 0.85m },
                    { 5, "70480", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Orbit/Sella WO", 1.28m },
                    { 4, "70470", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Brain W/WO", 1.27m },
                    { 3, "70450", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Brain WO", 0.85m },
                    { 35, "70540", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "MRI Neck/Face WO", 1.35m },
                    { 8, "70491", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Neck W", 1.38m },
                    { 17, "72131", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Lumbar Spine WO", 1.0m },
                    { 2, "71260", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Chest W", 1.24m },
                    { 26, "74150", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Abdomen WO", 1.19m },
                    { 33, "74178", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Abdomen/Pelvis W/WO", 2.01m },
                    { 32, "74177", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Abdomen/Pelvis W", 1.82m },
                    { 31, "74146", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Abdomen/Pelvis WO", 1.74m },
                    { 30, "74175", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CTA Abdomen W/WO", 1.82m },
                    { 29, "74174", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CTA Abdomen/Pelvis W/WO", 2.20m },
                    { 28, "74170", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Abdomen W/WO", 1.40m },
                    { 27, "74160", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Abdomen W", 1.27m },
                    { 18, "72132", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Lumbar Spine W", 1.22m },
                    { 25, "73706", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Lower Extremity W/WO", 1.9m },
                    { 24, "73701", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Lower Extremity W", 1.16m },
                    { 23, "73700", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Lower Extremity WO", 1.0m },
                    { 22, "73206", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CTA Upper Extremity W/WO", 1.81m },
                    { 21, "73200", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Upper Extremity WO", 1.0m },
                    { 20, "72193", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Pelvis W", 1.16m },
                    { 19, "721392", 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CT Pelvis WO", 1.09m }
          });

      migrationBuilder.InsertData(
          schema: "Common",
          table: "Goal",
          columns: new[] { "Id", "CreatedById", "CreatedDate", "DollarAmount", "LastModifiedById", "LastModifiedDate", "UserId", "YearId" },
          values: new object[,]
          {
                    { 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 100000m, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 100000m, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 3, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 100000m, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 }
          });

      migrationBuilder.InsertData(
          schema: "Common",
          table: "Service",
          columns: new[] { "Id", "CreatedById", "CreatedDate", "Description", "DoctorTypeId", "LastModifiedById", "LastModifiedDate", "Name", "ParentId" },
          values: new object[,]
          {
                    { 4, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "BI (PM)", null },
                    { 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-9PM", null },
                    { 22, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "DOB (PM)", null },
                    { 21, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEURO NON ACUTE (PM)", null },
                    { 20, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEURO NH/INPT (PM)", null },
                    { 3, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "BI (AM)", null },
                    { 18, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEURO ACUTE (AM)", null },
                    { 17, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEURO 4 (AM)", null },
                    { 16, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "MAMMO 3 (AM)", null },
                    { 15, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "MAMMO 2 (PM)", null },
                    { 19, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEURO ACUTE (PM)", null },
                    { 13, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "MAMMO 1 (PM)", null },
                    { 5, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "BI 3 (PM)", null },
                    { 14, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "MAMMO 2 (AM)", null },
                    { 6, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "BODY CT WL 1 (AM)", null },
                    { 7, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "BODY CT WL 1 (PM)", null },
                    { 9, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ED/TRAUMA (AM)", null },
                    { 2, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-11PM", null },
                    { 10, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "GENERAL (AM)", null },
                    { 11, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "GENERAL (PM)", null },
                    { 12, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "MAMMO 1 (AM)", null },
                    { 8, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "DOB (AM)", null }
          });

      migrationBuilder.InsertData(
          schema: "Common",
          table: "UserShiftType_xref",
          columns: new[] { "Id", "ShiftTypeId", "UserId" },
          values: new object[,]
          {
                    { 1, 1, 1 },
                    { 7, 3, 1 },
                    { 2, 1, 2 },
                    { 5, 2, 2 },
                    { 8, 3, 2 },
                    { 3, 1, 3 },
                    { 6, 2, 3 },
                    { 9, 3, 3 },
                    { 4, 2, 1 }
          });

      migrationBuilder.CreateIndex(
          name: "RoleNameIndex",
          schema: "Auth",
          table: "Role",
          column: "NormalizedName",
          unique: true,
          filter: "[NormalizedName] IS NOT NULL");

      migrationBuilder.CreateIndex(
          name: "IX_RoleClaim_RoleId",
          schema: "Auth",
          table: "RoleClaim",
          column: "RoleId");

      migrationBuilder.CreateIndex(
          name: "IX_User_DoctorTypeId",
          schema: "Auth",
          table: "User",
          column: "DoctorTypeId");

      migrationBuilder.CreateIndex(
          name: "EmailIndex",
          schema: "Auth",
          table: "User",
          column: "NormalizedEmail");

      migrationBuilder.CreateIndex(
          name: "UserNameIndex",
          schema: "Auth",
          table: "User",
          column: "NormalizedUserName",
          unique: true,
          filter: "[NormalizedUserName] IS NOT NULL");

      migrationBuilder.CreateIndex(
          name: "IX_User_ShiftTypeId",
          schema: "Auth",
          table: "User",
          column: "ShiftTypeId");

      migrationBuilder.CreateIndex(
          name: "IX_User_YearTypeId",
          schema: "Auth",
          table: "User",
          column: "YearTypeId");

      migrationBuilder.CreateIndex(
          name: "IX_UserClaim_UserId",
          schema: "Auth",
          table: "UserClaim",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_UserLogin_UserId",
          schema: "Auth",
          table: "UserLogin",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_Calendar_CreatedById",
          schema: "Common",
          table: "Calendar",
          column: "CreatedById");

      migrationBuilder.CreateIndex(
          name: "IX_Calendar_LastModifiedById",
          schema: "Common",
          table: "Calendar",
          column: "LastModifiedById");

      migrationBuilder.CreateIndex(
          name: "IX_Calendar_ParentId",
          schema: "Common",
          table: "Calendar",
          column: "ParentId");

      migrationBuilder.CreateIndex(
          name: "IX_Calendar_YearId",
          schema: "Common",
          table: "Calendar",
          column: "YearId");

      migrationBuilder.CreateIndex(
          name: "IX_CalendarEvent_CalendarEventTypeId",
          schema: "Common",
          table: "CalendarEvent",
          column: "CalendarEventTypeId");

      migrationBuilder.CreateIndex(
          name: "IX_CalendarEvent_CalendarId",
          schema: "Common",
          table: "CalendarEvent",
          column: "CalendarId");

      migrationBuilder.CreateIndex(
          name: "IX_CalendarEvent_CreatedById",
          schema: "Common",
          table: "CalendarEvent",
          column: "CreatedById");

      migrationBuilder.CreateIndex(
          name: "IX_CalendarEvent_LastModifiedById",
          schema: "Common",
          table: "CalendarEvent",
          column: "LastModifiedById");

      migrationBuilder.CreateIndex(
          name: "IX_Exam_CreatedById",
          schema: "Common",
          table: "Exam",
          column: "CreatedById");

      migrationBuilder.CreateIndex(
          name: "IX_Exam_ExamTypeId",
          schema: "Common",
          table: "Exam",
          column: "ExamTypeId");

      migrationBuilder.CreateIndex(
          name: "IX_Exam_LastModifiedById",
          schema: "Common",
          table: "Exam",
          column: "LastModifiedById");

      migrationBuilder.CreateIndex(
          name: "IX_Exam_ServiceId",
          schema: "Common",
          table: "Exam",
          column: "ServiceId");

      migrationBuilder.CreateIndex(
          name: "IX_Exam_ShiftId",
          schema: "Common",
          table: "Exam",
          column: "ShiftId");

      migrationBuilder.CreateIndex(
          name: "IX_Exam_UserId",
          schema: "Common",
          table: "Exam",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_ExamGroup_CreatedById",
          schema: "Common",
          table: "ExamGroup",
          column: "CreatedById");

      migrationBuilder.CreateIndex(
          name: "IX_ExamGroup_LastModifiedById",
          schema: "Common",
          table: "ExamGroup",
          column: "LastModifiedById");

      migrationBuilder.CreateIndex(
          name: "IX_ExamGroup_xref_ExamGroupId",
          schema: "Common",
          table: "ExamGroup_xref",
          column: "ExamGroupId");

      migrationBuilder.CreateIndex(
          name: "IX_ExamGroup_xref_ExamTypeId",
          schema: "Common",
          table: "ExamGroup_xref",
          column: "ExamTypeId");

      migrationBuilder.CreateIndex(
          name: "IX_ExamType_CreatedById",
          schema: "Common",
          table: "ExamType",
          column: "CreatedById");

      migrationBuilder.CreateIndex(
          name: "IX_ExamType_LastModifiedById",
          schema: "Common",
          table: "ExamType",
          column: "LastModifiedById");

      migrationBuilder.CreateIndex(
          name: "IX_ExamType_ModalityId",
          schema: "Common",
          table: "ExamType",
          column: "ModalityId");

      migrationBuilder.CreateIndex(
          name: "IX_Goal_CreatedById",
          schema: "Common",
          table: "Goal",
          column: "CreatedById");

      migrationBuilder.CreateIndex(
          name: "IX_Goal_LastModifiedById",
          schema: "Common",
          table: "Goal",
          column: "LastModifiedById");

      migrationBuilder.CreateIndex(
          name: "IX_Goal_UserId",
          schema: "Common",
          table: "Goal",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_Goal_YearId",
          schema: "Common",
          table: "Goal",
          column: "YearId");

      migrationBuilder.CreateIndex(
          name: "IX_Service_CreatedById",
          schema: "Common",
          table: "Service",
          column: "CreatedById");

      migrationBuilder.CreateIndex(
          name: "IX_Service_DoctorTypeId",
          schema: "Common",
          table: "Service",
          column: "DoctorTypeId");

      migrationBuilder.CreateIndex(
          name: "IX_Service_LastModifiedById",
          schema: "Common",
          table: "Service",
          column: "LastModifiedById");

      migrationBuilder.CreateIndex(
          name: "IX_Service_ParentId",
          schema: "Common",
          table: "Service",
          column: "ParentId");

      migrationBuilder.CreateIndex(
          name: "IX_ServiceExamType_xref_ExamTypeId",
          schema: "Common",
          table: "ServiceExamType_xref",
          column: "ExamTypeId");

      migrationBuilder.CreateIndex(
          name: "IX_ServiceExamType_xref_ServiceId",
          schema: "Common",
          table: "ServiceExamType_xref",
          column: "ServiceId");

      migrationBuilder.CreateIndex(
          name: "IX_Shift_CreatedById",
          schema: "Common",
          table: "Shift",
          column: "CreatedById");

      migrationBuilder.CreateIndex(
          name: "IX_Shift_LastModifiedById",
          schema: "Common",
          table: "Shift",
          column: "LastModifiedById");

      migrationBuilder.CreateIndex(
          name: "IX_Shift_ShiftTypeId",
          schema: "Common",
          table: "Shift",
          column: "ShiftTypeId");

      migrationBuilder.CreateIndex(
          name: "IX_Shift_UserId",
          schema: "Common",
          table: "Shift",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_ShiftService_xref_ServiceId",
          schema: "Common",
          table: "ShiftService_xref",
          column: "ServiceId");

      migrationBuilder.CreateIndex(
          name: "IX_ShiftService_xref_ShiftId",
          schema: "Common",
          table: "ShiftService_xref",
          column: "ShiftId");

      migrationBuilder.CreateIndex(
          name: "IX_UserShiftType_xref_ShiftTypeId",
          schema: "Common",
          table: "UserShiftType_xref",
          column: "ShiftTypeId");

      migrationBuilder.CreateIndex(
          name: "IX_UserShiftType_xref_UserId",
          schema: "Common",
          table: "UserShiftType_xref",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_Year_YearTypeId",
          schema: "Lookup",
          table: "Year",
          column: "YearTypeId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "RoleClaim",
          schema: "Auth");

      migrationBuilder.DropTable(
          name: "UserClaim",
          schema: "Auth");

      migrationBuilder.DropTable(
          name: "UserLogin",
          schema: "Auth");

      migrationBuilder.DropTable(
          name: "UserRole",
          schema: "Auth");

      migrationBuilder.DropTable(
          name: "UserToken",
          schema: "Auth");

      migrationBuilder.DropTable(
          name: "CalendarEvent",
          schema: "Common");

      migrationBuilder.DropTable(
          name: "Exam",
          schema: "Common");

      migrationBuilder.DropTable(
          name: "ExamGroup_xref",
          schema: "Common");

      migrationBuilder.DropTable(
          name: "Goal",
          schema: "Common");

      migrationBuilder.DropTable(
          name: "ServiceExamType_xref",
          schema: "Common");

      migrationBuilder.DropTable(
          name: "ShiftService_xref",
          schema: "Common");

      migrationBuilder.DropTable(
          name: "UserShiftType_xref",
          schema: "Common");

      migrationBuilder.DropTable(
          name: "Role",
          schema: "Auth");

      migrationBuilder.DropTable(
          name: "CalendarEventType",
          schema: "Lookup");

      migrationBuilder.DropTable(
          name: "Calendar",
          schema: "Common");

      migrationBuilder.DropTable(
          name: "ExamGroup",
          schema: "Common");

      migrationBuilder.DropTable(
          name: "ExamType",
          schema: "Common");

      migrationBuilder.DropTable(
          name: "Service",
          schema: "Common");

      migrationBuilder.DropTable(
          name: "Shift",
          schema: "Common");

      migrationBuilder.DropTable(
          name: "Year",
          schema: "Lookup");

      migrationBuilder.DropTable(
          name: "Modality",
          schema: "Lookup");

      migrationBuilder.DropTable(
          name: "User",
          schema: "Auth");

      migrationBuilder.DropTable(
          name: "DoctorType",
          schema: "Lookup");

      migrationBuilder.DropTable(
          name: "ShiftType",
          schema: "Common");

      migrationBuilder.DropTable(
          name: "YearType",
          schema: "Lookup");
    }
  }
}
