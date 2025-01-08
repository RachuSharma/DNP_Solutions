using WebApplicationSecound.Entities;

namespace WebApplicationNew.DTOs;

public class CreateStorageRoomDto
{
    public string Location { get; set; }
    public Dimension Dimensions { get; set; }
    public List<Box> Boxes { get; set; }
}