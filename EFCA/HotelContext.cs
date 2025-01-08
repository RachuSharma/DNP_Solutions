using EFCA.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCA;

public class HotelContext : DbContext
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //TODO: Download Microsoft.Data.Sqlite
        optionsBuilder.UseSqlite("Data Source=../../../Hotel.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>()
            .HasKey(r => r.Id);
        

        modelBuilder.Entity<Reservation>()
            .HasKey(r => r.Id);
        
    }
    
    
    
}