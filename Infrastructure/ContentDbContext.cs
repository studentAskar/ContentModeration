using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ContentDbContext : DbContext
{
    public ContentDbContext(DbContextOptions<ContentDbContext> options) : base(options) { }

    public DbSet<ContentItem> ContentItems => Set<ContentItem>();

    public DbSet<Video> Videos => Set<Video>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-5L36IOB\\SOLEXPRESS;Database=ContentDb;Trusted_Connection=True;MultipleActiveResultSets=true", options => options.CommandTimeout(1000));
    }
     
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_CI_AS");

        modelBuilder.Entity<Video>(entity =>
        {
            entity.Property(v => v.Status)
                .HasConversion<int>();

            entity.Property(v => v.FileName)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(v => v.FilePath)
                .IsRequired()
                .HasMaxLength(500);
        });
    }
}
