using EFCA.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCA;

public class HotelContext : DbContext
{
    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<Reservation> Reservations { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //TODO: Download Microsoft.Data.Sqlite
        //optionsBuilder.UseSqlite("Data Source=E:\\Semester3\\DNP\\ExamTest\\EFCA\\EFCA.csproj");
    }
}