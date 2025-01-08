using System.ComponentModel.DataAnnotations;

namespace EFCA.Entities;

public class Reservation
{
    [Key] 
    public int Id { get; set; }
   public string GuestName { get; set; } = null!;
   public DateTime CheckInDate { get; set; }
   public int NumberOfNights { get; set; }
   public bool BreakfastIncluded { get; set; }
   
    public Room? Room { get; set; }
    
    public int RoomNumber { get; set; } // Foreign key property
    
    public int FloorNumber { get; set; } // Foreign key property
    
    
   
   //Constructor
   
    public Reservation()
    {
         
    }
    
    
    
}