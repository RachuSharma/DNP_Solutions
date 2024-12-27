namespace WebApplicationSecound.Entities;

public class StorageRoom
{
    public int StorageRoomId { get; set; }
    public string Location { get; set; }
    public Dimension Dimensions { get; set; }
    public List<Box> Boxes { get; set; }
}