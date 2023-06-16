using Microsoft.EntityFrameworkCore;
using si730pc2u20201b338.Infrastructure.Models;

namespace si730pc2u20201b338.Infrastructure.Context;

public class ProjectContext : DbContext
{
    public ProjectContext()
    {
        
    }
    
    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
    {
        
    }
    
    public DbSet<Destination> Destinations { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
        optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=12345678;Database=traveleres;", serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //Destination
        builder.Entity<Destination>().ToTable("Destinations");
        builder.Entity<Destination>().HasKey(p => p.Id);
        builder.Entity<Destination>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Destination>().Property(p => p.Name).IsRequired();
        builder.Entity<Destination>().Property(p => p.maxUsers).IsRequired();
        builder.Entity<Destination>().Property(p => p.isRisky).IsRequired();
        
    }
}