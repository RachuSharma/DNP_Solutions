using EFCA.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCA;

public class DataAccess
{
    private readonly HotelContext _ctx;

    public DataAccess(HotelContext ctx)
    {
        this._ctx = ctx;
    }

    //Create a room
    public async Task CreateRoomAsync(Room room)
    {
        try
        {
            _ctx.Rooms.Add(room);
            await _ctx.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error in creating room: " + e.InnerException?.Message);
        }
    }

    //Add reservation to the room
    public async Task AddReservationAsync(int roomId, int floorNumber, Reservation reservation)
    {
        try
        {
            var room = await _ctx.Rooms.FindAsync(roomId);
            if (room != null && room.FloorNumber == floorNumber)
            {
                room.Reservations.Add(reservation);
                await _ctx.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Room not found");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error in adding reservation: " + e.Message);
        }
    }

    //Get rooms with filter
    public async Task<List<Room>> GetRoomsAsync(int numberOfBeds, bool hasSpa)
    {
        try
        {
            return await _ctx.Rooms
                .Where(r => r.NumberOfBeds == numberOfBeds && r.HasSpa == hasSpa)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error in getting rooms: " + e.Message);
            return new List<Room>();
        }
    }

    //Get all rooms
    public async Task<List<Room>> GetAllRoomsAsync()
    {
        try
        {
            return await _ctx.Rooms.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error in getting rooms: " + e.Message);
            return new List<Room>();
        }
    }

    //Get earnings for date interval
    /*public async Task<int> GetEarningsAsync(DateTime startDate, DateTime endDate)
    {
        try
        {
            var reservations = await _ctx.Reservations
                .Where(r => r.CheckInDate >= startDate && r.CheckInDate <= endDate)
                .ToListAsync();
            return reservations.Sum(r => r.Room.PricePerNight * r.NumberOfNights + (r.BreakfastIncluded ? 20 : 0));
        }
        catch (Exception e)
        {
            Console.WriteLine("Error in getting earnings: " + e.Message);
            return 0;
        }
    }*/
}