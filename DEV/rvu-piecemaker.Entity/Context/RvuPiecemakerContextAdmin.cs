using CAIU.Common;
using Microsoft.EntityFrameworkCore;

namespace RvuPiecemaker.Entities.Context
{
    public partial class RvuPiecemakerContext
  {
    public virtual DbSet<ErrorLog> ErrorLog { get; set; }
    public void OnModelCreating_Admin(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ErrorLog>(entity =>
      {
        entity.ToTable("ErrorLog", "Admin");
      });
    }
  }
}
