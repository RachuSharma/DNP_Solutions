namespace WebApiA.Entities;

public class Profile
{
    public int ProfileId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    
    public List<Like> LikedProfiles { get; set; } = new();
    
    //Constructor
    public Profile(int profileId,string name, int age, string gender, List<Like> likes)
    {
        ProfileId = profileId;
        Name = name;
        Age = age;
        Gender = gender;
        LikedProfiles = likes;
        
    }
    
    public Profile()
    {
        
    }
}