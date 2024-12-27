using WebApplicationSecound.Entities;

namespace WebApplicationSecound.Service;

public class StorageService : IStorageService
{
    private List<StorageRoom> _storageRooms = [];
    private List<Box> _boxes = [];


    public StorageService()
    {
        _storageRooms.Add(new StorageRoom
        {
            StorageRoomId = 1, Location = "row 1", Dimensions = new Dimension
            {
                Length = 10, Width = 10, Height = 10
            },
            Boxes = new List<Box>
            {
                new Box
                {
                    BoxId = 1, Label = "Kitchen", Dimensions = new Dimension
                    {
                        Length = 1, Width = 1, Height = 1
                    }
                }
            }
        });

        _storageRooms.Add(new StorageRoom
        {
            StorageRoomId = 2, Location = "aisle 2", Dimensions = new Dimension
            {
                Length = 20, Width = 20, Height = 20
            },
            Boxes = new List<Box>
            {
                new Box
                {
                    BoxId = 1, Label = "Old Books", Dimensions = new Dimension
                    {
                        Length = 2, Width = 2, Height = 2
                    }
                }
            }
        });

        _storageRooms.Add(new StorageRoom
        {
            StorageRoomId = 3, Location = "shelf 3", Dimensions = new Dimension
            {
                Length = 30, Width = 30, Height = 30
            },
            Boxes = new List<Box>
            {
                new Box
                {
                    BoxId = 1, Label = "New Books", Dimensions = new Dimension
                    {
                        Length = 3, Width = 3, Height = 3
                    }
                }
            }
        });

        _storageRooms.Add(new StorageRoom
        {
            StorageRoomId = 4, Location = "room 4", Dimensions = new Dimension
            {
                Length = 40, Width = 40, Height = 40
            },
            Boxes = new List<Box>
            {
                new Box
                {
                    BoxId = 1, Label = "Old Toys", Dimensions = new Dimension
                    {
                        Length = 4, Width = 4, Height = 4
                    }
                }
            }
        });

        _storageRooms.Add(new StorageRoom
        {
            StorageRoomId = 5, Location = "floor 5", Dimensions = new Dimension
            {
                Length = 50, Width = 50, Height = 50
            },
            Boxes = new List<Box>
            {
                new Box
                {
                    BoxId = 1, Label = "New Toys", Dimensions = new Dimension
                    {
                        Length = 5, Width = 5, Height = 5
                    }
                }
            }
        });
    }

    public Task<Box> AddBoxAsync(int storageRoomId ,Box box)
    {
        Console.WriteLine(_boxes.Count);
        box.BoxId = _boxes.Any()
            ? _boxes.Max(p => p.BoxId) + 1
            : 1;
        _boxes.Add(box);
        Console.WriteLine(_boxes.Count);
        return Task.FromResult(box);
    }

    public Task<Box> GetBoxByIdAsync(int storageRoomId, int boxId)
    {
        var storageRoom = _storageRooms.FirstOrDefault(p => p.StorageRoomId == storageRoomId);
        var box = _boxes.FirstOrDefault(p => p.BoxId == boxId);
        if (box is null)
        {
            throw new Exception(
                $"Box with ID '{boxId}' not found");
        }
    
        return Task.FromResult(box);
        
    }
    

    public Task DeleteBoxAsync( int storageRoomId, int boxId)
    {
        var BoxToRemove = _boxes.SingleOrDefault(p => p.BoxId == boxId);
        if (BoxToRemove is null)
        {
            throw new Exception(
                $"Box with ID '{boxId}' not found");
        }

        _boxes.Remove(BoxToRemove);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<StorageRoom>> GetAllStorageRoomsAsync(StorageRoom? storageRoom = null)
    {
        IEnumerable<StorageRoom> filteredStorageRooms = _storageRooms;
        if (storageRoom != null)
        {

            // filter with specific cubic meters greaten then specafi number of storage room
            filteredStorageRooms =
                filteredStorageRooms.Where(p => p.Dimensions.CubicMeters > storageRoom.Dimensions.CubicMeters);
        }

        if (storageRoom != null)
            // filter with LESS THEN specific NUMBER OF BOXES
            filteredStorageRooms = filteredStorageRooms.Where(p => p.Boxes.Count < storageRoom.Boxes.Count);

        return Task.FromResult(filteredStorageRooms);
    }


}