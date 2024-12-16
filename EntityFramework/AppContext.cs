using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework;

public class AppContext : DbContext
{
    public DbSet<Show> Shows { get; set; } = null!;
    public DbSet<Episode> Episodes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=shows.db");
    }
}