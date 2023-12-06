using KitchenService.Domain;
using Microsoft.EntityFrameworkCore;

namespace KitchenService.EntityFramework;

public class KitchenDbContext : DbContext
{
    public DbSet<Ticket> Tickets { get; set; } = null!;
    
    public KitchenDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}