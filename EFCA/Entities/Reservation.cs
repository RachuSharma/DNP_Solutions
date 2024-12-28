using System.ComponentModel.DataAnnotations;

namespace EFCA.Entities;

public class Reservation
{
   public string GuestName { get; set; } = null!;
   public int CheckInDate { get; set; }
   public int NumberOfNights { get; set; }
   public bool BreakfastIncluded { get; set; }
   
   //Constructor
   public Reservation(string guestName, int checkInDate, int numberOfNights, bool breakfastIncluded)
   {
       GuestName = guestName;
       CheckInDate = checkInDate;
       NumberOfNights = numberOfNights;
       BreakfastIncluded = breakfastIncluded;
   }
   
    public Reservation()
    {
         
    }
    
    
    
}