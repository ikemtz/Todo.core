using Microsoft.EntityFrameworkCore;
using m = ToDo.Abstraction.Models;

namespace ToDo.Data
{
  public partial class ToDoContext : DbContext
  {
    public virtual DbSet<Abstraction.Models.ToDo> ToDos { get; set; }

    public ToDoContext(DbContextOptions<ToDoContext> options)
    : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<m.ToDo>(entity =>
      {
        entity.ForSqlServerToTable("ToDos");
        entity.Property(e => e.CreatedOnUtc)
                  .HasColumnType("datetime")
                  .HasDefaultValueSql("getutcdate()");

        entity.Property(e => e.DeletedOnUtc).HasColumnType("datetime");

        entity.Property(e => e.Description).IsRequired();

        entity.Property(e => e.Title)
                  .IsRequired()
                  .HasMaxLength(50);

        entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");
      });
    }
  }
}