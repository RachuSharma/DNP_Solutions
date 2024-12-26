namespace WebApi.Entities;

public class UserStory
{
    public int UserStoryId { get; set; }
    public string Description { get; set; }
    public float Estimate { get; set; }
    
    public UserStory(string description, float estimate)
    {
        Description = description;
        Estimate = estimate;
}

    public UserStory()
    {
    }
}