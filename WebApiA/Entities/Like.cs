namespace WebApiA.Entities;

public class Like
{
    public int LikedProfileId { get; set; }
    
    //Constructor
    public Like(int likedProfileId)
    {
        LikedProfileId = likedProfileId;
    }
    
    public Like()
    {
        
    }
}