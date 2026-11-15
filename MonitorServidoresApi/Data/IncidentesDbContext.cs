using Microsoft.EntityFrameworkCore;
using MonitorServidoresApi.Models;

namespace MonitorServidoresApi.Data;

public class IncidentesDbContext : DbContext
{
    public IncidentesDbContext(DbContextOptions<IncidentesDbContext> options)
        : base(options)
    {
    }

    public DbSet<Incidente> Incidentes => Set<Incidente>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Incidente>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Gravedad).HasDefaultValue("media");
            entity.Property(e => e.Estado).HasDefaultValue("abierto");
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
    }
}
