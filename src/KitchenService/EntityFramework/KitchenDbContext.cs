using System.Linq.Expressions;
using KitchenService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<InternalId>()
            .HaveConversion<InternalIdConverter>();
    }
}

public class InternalIdConverter : ValueConverter<InternalId, string>
{
    public InternalIdConverter() : base(id => id.Value, rawId => new InternalId(rawId))
    {
        
    }
}