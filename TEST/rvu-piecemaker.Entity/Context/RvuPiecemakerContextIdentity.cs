using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RvuPiecemaker.Entities.DataClasses;

namespace RvuPiecemaker.Entities.Context
{
  public partial class RvuPiecemakerContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
  {
    public void OnModelCreating_Identity(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ApplicationUser>(e =>
      {
        e.ToTable("User", "Auth");

        //e.Property(d => d.ShiftTypeId).HasDefaultValue(1);

        //e.Property(d => d.YearTypeId).HasDefaultValue(1);

        e.HasOne(d => d.DoctorType)
                  .WithMany(p => p.Users)
                  .HasForeignKey(d => d.DoctorTypeId)
                  .HasConstraintName("FK_ApplicationUser_DoctorType");

        e.HasOne(d => d.ShiftType)
                  .WithMany(p => p.Users)
                  .HasForeignKey(d => d.ShiftTypeId)
                  .HasConstraintName("FK_ApplicationUser_ShiftType");

        e.HasOne(d => d.YearType)
                  .WithMany(p => p.Users)
                  .HasForeignKey(d => d.YearTypeId)
                  .HasConstraintName("FK_ApplicationUser_YearType");

        e.HasData(
          new ApplicationUser
          {
            Id = 1,
            AccessFailedCount = 0,
            ConcurrencyStamp = "f605120f-716d-40c3-9dbd-8ff473410823",
            Email = "gelbaughcm@gmail.com",
            EmailConfirmed = false,
            FirstName = "System",
            LastName = "Administrator",
            LockoutEnabled = false,
            NormalizedEmail = "GELBAUGHCM@GMAIL.COM",
            NormalizedUserName = "GELBAUGHCM@GMAIL.COM",
            PasswordHash = "AQAAAAEAACcQAAAAEOArtYDjNhZZ70ALB8gN48bBCYBvnHqlujqi9YvoQLZheFnvqYIS0X9xI3BHGchHdg==",
            SecurityStamp = "dfafd561-8cef-40ad-8c7a-339dc67529d0",
            UserName = "gelbaughcm@gmail.com",
            DoctorTypeId = null,
            ShiftTypeId = 1,
            YearTypeId = 1,
            RvuRate = 33.3m
          },
          new ApplicationUser
          {
            Id = 2,
            AccessFailedCount = 0,
            ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
            Email = "dmartingrad@gmail.com",
            EmailConfirmed = false,
            FirstName = "Doug",
            LastName = "Martin",
            LockoutEnabled = false,
            NormalizedEmail = "DMARTINGRAD@GMAIL.COM",
            NormalizedUserName = "DMARTINGRAD@GMAIL.COM",
            PasswordHash = "AQAAAAEAACcQAAAAEOArtYDjNhZZ70ALB8gN48bBCYBvnHqlujqi9YvoQLZheFnvqYIS0X9xI3BHGchHdg==",
            SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
            UserName = "dmartingrad@gmail.com",
            DoctorTypeId = 1,
            ShiftTypeId = 1,
            YearTypeId = 1,
            RvuRate = null
          },
          new ApplicationUser
          {
            Id = 3,
            AccessFailedCount = 0,
            ConcurrencyStamp = "8162aab4-994a-4a36-b184-867c083484c3",
            Email = "pspotok@verizon.net",
            EmailConfirmed = false,
            FirstName = "Paul",
            LastName = "Potok",
            LockoutEnabled = false,
            NormalizedEmail = "PSPOTOK@VERIZON.NET",
            NormalizedUserName = "PSPOTOK@VERIZON.NET",
            PasswordHash = "AQAAAAEAACcQAAAAEOArtYDjNhZZ70ALB8gN48bBCYBvnHqlujqi9YvoQLZheFnvqYIS0X9xI3BHGchHdg==",
            SecurityStamp = "MKZ5DGRD44RCRJFUGZTIYTWZJ2IXSHUE",
            UserName = "pspotok@verizon.net",
            DoctorTypeId = 1,
            ShiftTypeId = 1,
            YearTypeId = 1,
            RvuRate = null
          }
          );

      });
      modelBuilder.Entity<ApplicationRole>(e =>
      {
        e.ToTable("Role", "Auth");
      });

      modelBuilder.Entity<IdentityUserClaim<int>>(e =>
      {
        e.ToTable("UserClaim", "Auth");
      });
      modelBuilder.Entity<IdentityUserLogin<int>>(e =>
      {
        e.ToTable("UserLogin", "Auth");
        e.HasKey(x => new { x.ProviderKey, x.LoginProvider });
      });
      modelBuilder.Entity<IdentityUserToken<int>>(e =>
      {
        e.ToTable("UserToken", "Auth");
        e.HasKey(x => new { x.UserId, x.Value, x.LoginProvider });
      });
      modelBuilder.Entity<IdentityUserRole<int>>(e =>
      {
        e.ToTable("UserRole", "Auth");
        e.HasKey(x => new { x.RoleId, x.UserId });
      });
      modelBuilder.Entity<IdentityRoleClaim<int>>(e =>
      {
        e.ToTable("RoleClaim", "Auth");
      });
    }
  }
}
