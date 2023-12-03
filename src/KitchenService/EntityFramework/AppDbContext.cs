using KitchenService.Domain;
using Microsoft.EntityFrameworkCore;

namespace KitchenService.EntityFramework;

public class AppDbContext : DbContext
{
    public DbSet<Ticket> Tickets { get; set; } = null!;
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}