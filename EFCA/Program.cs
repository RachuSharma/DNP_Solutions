// See https://aka.ms/new-console-template for more information

using EFCA;
using EFCA.Entities;

var ctx = new HotelContext();
var dataAccess = new DataAccess(ctx);

    

    var room1 = new Room
    {
        Theme = "Modern",
        FloorNumber = 1,
        RoomNumber = 101,
        PricePerNight = 100,
        NumberOfBeds = 2,
        HasSpa = true
    };

    var room2 = new Room
    {
        Theme = "Classic",
        FloorNumber = 2,
        RoomNumber = 201,
        PricePerNight = 80,
        NumberOfBeds = 1,
        HasSpa = false
    };

    var room3 = new Room
    {
        Theme = "Modern",
        FloorNumber = 2,
        RoomNumber = 202,
        PricePerNight = 120,
        NumberOfBeds = 3,
        HasSpa = true
    };

    var reservation1 = new Reservation
    {
        GuestName = "John Doe",
        CheckInDate = DateTime.Now,
        NumberOfNights = 3,
        BreakfastIncluded = true,
        RoomNumber = 101,
        FloorNumber = 1
    };

    var reservation2 = new Reservation
    {
        GuestName = "Jane Doe",
        CheckInDate = DateTime.Now,
        NumberOfNights = 2,
        BreakfastIncluded = false,
        RoomNumber = 201
    };

    var reservation3 = new Reservation
    {
        GuestName = "Jane Doe",
        CheckInDate = DateTime.Now,
        NumberOfNights = 2,
        BreakfastIncluded = false,
        RoomNumber = 202
    };

    

    await dataAccess.CreateRoomAsync(room1);
    await dataAccess.CreateRoomAsync(room2);
    await dataAccess.CreateRoomAsync(room3);
    


    
    await dataAccess.AddReservationAsync(1, 1, reservation1);

    var allRooms = await dataAccess.GetAllRoomsAsync();
    foreach (var VARIABLE in allRooms )
    {
     Console.WriteLine(VARIABLE.Id);   
    }
        
    var rooms = await dataAccess.GetRoomsAsync(2, true);
    foreach (var room in rooms)
    {
        Console.WriteLine(room);
    }
        
Console.ReadLine();