using Microsoft.EntityFrameworkCore;
using ZeFiveNime.Models;
public class ZeFiveNimeDbContext : DbContext {
    public DbSet<Animation> Animation { get; set; }
    public DbSet<Episode> Episode { get; set; }
    public DbSet<Source> Source { get; set; }

    public ZeFiveNimeDbContext(DbContextOptions<ZeFiveNimeDbContext>options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animation>()
            .HasMany(a => a.Episodes)
            .WithOne(e => e.Animation)
            .HasForeignKey(e => e.Id_Animation);

        modelBuilder.Entity<Episode>()
            .HasMany(e => e.Sources)
            .WithOne(s => s.Episode)
            .HasForeignKey(s => s.Episode_SourceId);

        base.OnModelCreating(modelBuilder);
    }
}