using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RvuPiecemaker.Entities.Context
{
  public partial class RvuPiecemakerContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    public RvuPiecemakerContext(DbContextOptions<RvuPiecemakerContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      this.OnModelCreating_Identity(modelBuilder);
      this.OnModelCreating_Admin(modelBuilder);
      this.OnModelCreating_Lookup(modelBuilder);
      this.OnModelCreating_Calendar(modelBuilder);
      this.OnModelCreating_Common(modelBuilder);
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RvuPiecemakerContext>
    {
      public RvuPiecemakerContext CreateDbContext(string[] args)
      {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var builder = new DbContextOptionsBuilder<RvuPiecemakerContext>();
        var connectionString = configuration.GetConnectionString("rvu");
        builder.UseSqlServer(connectionString);
        return new RvuPiecemakerContext(builder.Options);
      }
    }
  }
}
