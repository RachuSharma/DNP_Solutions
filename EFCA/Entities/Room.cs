using System.ComponentModel.DataAnnotations;

namespace EFCA.Entities;

public class Room
{
    [Key]
    public int Id { get; set; }
    public string? Theme { get; set; } = null!;
    public int FloorNumber { get; set; }
    public int RoomNumber { get; set; }
    public int PricePerNight { get; set; }
    public int NumberOfBeds { get; set; }
    public bool HasSpa { get; set; }
    
    public int ReservationId { get; set; }
    public List<Reservation> Reservations { get; set; }
    
    
    //Constructor
    
    public Room()
    {
         
    }
}