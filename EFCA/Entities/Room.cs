﻿namespace EFCA.Entities;

public class Room
{
    public string Theme { get; set; } = null!;
    public int FloorNumber { get; set; }
    public int RoomNumber { get; set; }
    public int PricePerNight { get; set; }
    public int NumberOfBeds { get; set; }
    public bool HasSpa { get; set; }
    
    
    //Constructor
    public Room(string theme, int floorNumber, int roomNumber, int pricePerNight, int numberOfBeds, bool hasSpa)
    {
        Theme = theme;
        FloorNumber = floorNumber;
        RoomNumber = roomNumber;
        PricePerNight = pricePerNight;
        NumberOfBeds = numberOfBeds;
        HasSpa = hasSpa;
    }
    
    public Room()
    {
         
    }
}