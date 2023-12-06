using KitchenService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitchenService.EntityFramework;

public class KitchenDbContext : DbContext
{
    public DbSet<Ticket> Tickets { get; set; } = null!;
    
    public KitchenDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureTicket(modelBuilder.Entity<Ticket>());
    }

    private void ConfigureTicket(EntityTypeBuilder<Ticket> builder)
    {
        builder.Property(t => t.InternalId).HasMaxLength(128);
        builder.HasIndex(t => t.InternalId).IsUnique();
    }
}